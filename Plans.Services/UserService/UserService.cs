namespace Plants.Services.UserService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Pet;
	using static Constants.GlobalConstants.ApiConstants;
	using Models;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Azure.Storage.Blobs;
	using SendGrid.Helpers.Errors.Model;
	using System;
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel;

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

		public async Task<FirstLoginViewModel> GetModels()
		{
			var cities = _repository.AllReadOnly<Region>().OrderBy(x => x.Name);
			var pets = _repository.AllReadOnly<Pet>().OrderBy(x => x.Name);

			var citiesViewModels = _mapper.Map<IEnumerable<RegionViewModel>>(cities);
			var petsViewModels = _mapper.Map<IEnumerable<PetViewModel>>(pets);

			var model = new FirstLoginViewModel()
			{
				Regions = citiesViewModels,
				Pets = petsViewModels,
			};

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

		public async Task AddUserInformation(FirstLoginViewModel model, string url, string userId)
		{
			var user = await _repository
				.AllReadOnly<ApplicationUser>()
				.Include(x => x.UserConfiguration)
				.FirstOrDefaultAsync(x => x.Id == userId);

			var region = await _repository
				.FindByIdAsync<Region>(model.RegionId);

			if (user.UserConfigurationIsNull == false)
			{
				if (user.UserConfiguration.UserPictureUrl != null)
				{
					await DeleteFileAsync(user.UserConfiguration.UserPictureUrl, user.Id);
				}
			}
			if (user != null && region != null)
			{
				var userConfiguration = _mapper.Map<UserConfiguration>(model);

				userConfiguration.Region = region;
				userConfiguration.ApplicationUser = user;
				userConfiguration.UserPictureUrl = url;

				user.UserConfiguration = userConfiguration;
				user.UserConfigurationIsNull = false;

				//vij ako veche go ima kak da go opravq

				_repository.UpdateAsync(user);
				await _repository.SaveChangesAsync();
				user.UsersConfigurationId = userConfiguration.Id;
			}

			await _repository.SaveChangesAsync();
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
