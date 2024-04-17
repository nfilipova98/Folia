namespace Plants.Services.UserService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Pet;
	using static Constants.GlobalConstants.ApiConstants;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Azure.Storage.Blobs;
	using Microsoft.EntityFrameworkCore;
	using SendGrid.Helpers.Errors.Model;
	using System;

	public class UserService : IUserService
	{
		private IRepositoryService _repository;
		private readonly IMapper _mapper;
		private readonly BlobServiceClient _blobServiceClient;

		public UserService(IRepositoryService repository, IMapper mapper, BlobServiceClient blobServiceClient)
		{
			_repository = repository;
			_mapper = mapper;
			_blobServiceClient = blobServiceClient;
		}

		public async Task<ProfileViewModel> GetModels(string? userId)
		{
			var regions = _repository.AllReadOnly<Region>().OrderBy(x => x.Name);
			var pets = _repository.AllReadOnly<Pet>().OrderBy(x => x.Name);

			var regionsViewModels = _mapper.Map<IEnumerable<RegionViewModel>>(regions);
			var petsViewModels = _mapper.Map<IEnumerable<PetViewModel>>(pets);

			var model = new ProfileViewModel()
			{
				Regions = regionsViewModels,
				Pets = petsViewModels,
			};

			if (userId != null)
			{
				var userConfg = await _repository
					.AllReadOnly<UserConfiguration>()
					.Include(x => x.Pets)
					.FirstOrDefaultAsync(x => x.ApplicationUserId == userId);

				if (userConfg != null)
				{
					_mapper.Map(userConfg, model);
				}
			}

			return model;
		}

		public async Task<string> UploadFileAsync(ImageModel file)
		{
			var fileName = Guid.NewGuid().ToString();
			using var fileStream = file.FormFile.OpenReadStream();

			var blobClient = GetBlobClient(fileName);

			using (var stream = file.FormFile.OpenReadStream())
			{
				await blobClient.UploadAsync(stream);
			}

			return blobClient.Uri.ToString();
		}

		public async Task AddUserInformation(ProfileViewModel model, string url, string userId)
		{
			var user = await _repository
				.All<ApplicationUser>()
				.Include(x => x.UserConfiguration)
				.ThenInclude(x => x.Pets)
				.FirstOrDefaultAsync(x => x.Id == userId);

			var region = await _repository
				.FindByIdAsync<Region>(model.RegionId);

			var userConfiguration = user?.UserConfiguration;

			using var transaction = _repository.CreateTransaction();

			if (user != null && userConfiguration?.UserPictureUrl != null && model.ImageModel != null)
			{
				await DeleteFileAsync(userConfiguration.UserPictureUrl, userConfiguration.ApplicationUserId);
			}
			if (user != null && region != null)
			{
				if (userConfiguration == null)
				{
					userConfiguration = new UserConfiguration();
				}

				_mapper.Map(model, userConfiguration);

				if (!string.IsNullOrEmpty(url))
				{
					userConfiguration.UserPictureUrl = url;
				}

				var petIds = model.PetIds;

				var pets = await _repository
					.All<Pet>()
					.Where(x => petIds.Contains(x.Id))
					.ToListAsync();

				if (userConfiguration.Id != default)
				{
					userConfiguration.Pets.Clear();
					await _repository.SaveChangesAsync();
					userConfiguration.Pets = pets;

					_repository.Update(userConfiguration);
				}
				else
				{
					user.UserConfigurationIsNull = false;
					userConfiguration.Pets = pets;
					await _repository.AddAsync(userConfiguration);
				}
			}

			await _repository.SaveChangesAsync();
			await transaction.CommitAsync();
		}

		public async Task DeleteFileAsync(string url, string userId)
		{
			var user = await _repository
				.AllReadOnly<ApplicationUser>()
				.Where(x => x.Id == userId)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				throw new NotFoundException();
			}

			var fileName = Path.GetFileName(url);

			var blobClient = GetBlobClient(fileName);
			await blobClient.DeleteIfExistsAsync();
		}

		private BlobClient GetBlobClient(string fileName)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
			return blobContainerClient.GetBlobClient(fileName);
		}
	}
}
