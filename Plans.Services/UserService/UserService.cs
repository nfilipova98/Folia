namespace Plants.Services.UserService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Data.Models.Pet;
	using static Constants.GlobalConstants.ApiConstants;
	using Models;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Azure.Storage.Blobs;
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

		public async Task<FirstLoginViewModel> GetModels()
		{
			var cities = _repository.AllReadOnly<City>();
			var pets = _repository.AllReadOnly<Pet>();

			var citiesViewModels = _mapper.Map<IEnumerable<CityViewModel>>(cities);
			var petsViewModels = _mapper.Map<IEnumerable<PetViewModel>>(pets);

			var model = new FirstLoginViewModel()
			{
				Cities = citiesViewModels,
				Pets = petsViewModels,
			};

			return model;
		}

		public async Task<Tier?> FindUserByIdAsync(string userId)
		{
			var user = await _repository.FindByIdAsync<ApplicationUser>(userId);

			return user?.Tier;
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
				.FindByIdAsync<ApplicationUser>(userId);

			var city = await _repository
				.FindByIdAsync<City>(model.CityId);

			if (user.UserPictureUrl != null)
			{
				await DeleteFileAsync(user.UserPictureUrl, user.Id);
			}

			if (user != null && city != null)
			{
				var userConfiguration = _mapper.Map<UserConfiguration>(model);
				userConfiguration.City = city;
				userConfiguration.ApplicationUser = user;

				await _repository.AddAsync(userConfiguration);
			}

			await _repository.SaveChangesAsync();
		}

		public async Task DeleteFileAsync(string url, string userId)
		{
			var plant = await _repository
				.FindByIdAsync<ApplicationUser>(userId);

			if (plant == null)
			{
				throw new NotFoundException();
			}

			var fileName = Path.GetFileName(url);

			var blobClient = GetBlobClient(fileName);
			await blobClient.DeleteIfExistsAsync();

			_repository.Delete(plant);
			await _repository.SaveChangesAsync();
		}

		private BlobClient GetBlobClient(string fileName)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
			return blobContainerClient.GetBlobClient(fileName);
		}
	}
}
