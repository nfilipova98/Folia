namespace Plants.Services.PlantService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using RepositoryService;
	using static Constants.GlobalConstants.ApiConstants;
	using static Services.Constants.GlobalConstants.Paging;
	using Services.RegionService;
	using ViewModels;

	using AutoMapper;
	using Azure.Storage.Blobs;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using SendGrid.Helpers.Errors.Model;

	public class PlantService : IPlantService
	{
		private readonly IRepositoryService _repository;
		private readonly IRegionService _regionService;
		private readonly IMapper _mapper;
		private readonly BlobServiceClient _blobServiceClient;

		public PlantService(IRepositoryService repository, IRegionService regionService, IMapper mapper, BlobServiceClient blobServiceClient)
		{
			_repository = repository;
			_regionService = regionService;
			_mapper = mapper;
			_blobServiceClient = blobServiceClient;
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await _repository.AllReadOnly<Plant>()
				.AnyAsync(x => x.Id == id);
		}

		public async Task<PlantEditOrAddViewModel> GetPlantAddOrEditModelAsync(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			return _mapper.Map<PlantEditOrAddViewModel>(plant);
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

		public async Task CreatePlantAsync(string fileUrl, PlantEditOrAddViewModel model)
		{
			var petIds = model.PetIds;

			var pets = await _repository.All<Pet>()
				.Where(x => petIds.Contains(x.Id))
				.ToListAsync();

			var plant = _mapper.Map<Plant>(model);
			plant.ImageUrl = fileUrl;

			await _repository.AddAsync(plant);

			if (pets.Count != 0)
			{
				foreach (var item in pets)
				{
					plant.Pets.Add(item);
				}
			}

			await _repository.SaveChangesAsync();
		}

		public async Task<PlantDeleteViewModel> DeleteAsync(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			if (plant == null)
			{
				throw new NotFoundException();
			}

			return _mapper.Map<PlantDeleteViewModel>(plant);
		}

		public async Task DeleteFileAsync(string url, int plantId)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(plantId);

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

		public async Task<IEnumerable<int>> GetPetIds(int plantId)
		{
			var petIds = _repository
				.AllReadOnly<Plant>()
				.Where(plant => plant.Id == plantId)
				.SelectMany(plant => plant.Pets.Select(pet => pet.Id))
				.ToList();

			return petIds;
		}

		public async Task<IEnumerable<PlantAllViewModel>> GetAllPlantsAsync
			(string userId,
			string? searchString,
			bool? kidSafe,
			bool? petSafe,
			Lifestyle? lifestyle,
			Difficulty? difficulty,
			int? regionId)
		{

			var plantsToShow = _repository.AllReadOnly<Plant>();

			if (kidSafe != null)
			{
				plantsToShow = plantsToShow.Where(x => x.KidSafe == kidSafe);
			}
			if (lifestyle != null)
			{
				plantsToShow = plantsToShow.Where(x => x.Lifestyle == lifestyle);
			}
			if (difficulty != null)
			{
				plantsToShow = plantsToShow.Where(x => x.Difficulty == difficulty);
			}
			if (petSafe != null)
			{
				plantsToShow = plantsToShow.Where(x => x.Pets.Count == 0);
			}
			if (regionId != null)
			{
				var region = await _repository
					.FindByIdAsync<Region>(regionId.Value);

				string regionName = region.Name;

				var humidityPercentage = await _regionService.GetHumidityAsync(regionName);

				var humidity = HumidityFromPercentage(humidityPercentage);

				if (humidity != null)
				{
					plantsToShow = plantsToShow.Where(x => x.Humidity == humidity);
				}
			}
			if (searchString != null)
			{
				string normalizedSearchTerm = searchString.ToLower();

				plantsToShow = plantsToShow
				   .Where(x => x.Name.ToLower().Contains(normalizedSearchTerm) ||
									  x.ScientificName.ToLower().Contains(normalizedSearchTerm));
			}

			var plants = await plantsToShow
				.Include(x => x.UsersLikedPlant)
				.OrderByDescending(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<Plant>, List<PlantAllViewModel>>(plants, opt => opt.Items["userId"] = userId);

			return model;
		}

		public async Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants(string userId)
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Include(x => x.UsersLikedPlant)
				.Where(x => x.IsTrending)
				.OrderBy(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<Plant>, List<PlantHomeViewModel>>(plants, opt => opt.Items["userId"] = userId);

			return model;
		}

		public async Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync(string userId)
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Include(x => x.UsersLikedPlant)
				.Where(x => x.UsersLikedPlant.Any(x => x.Id == userId))
				.OrderByDescending(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<Plant>, List<PlantAllViewModel>>(plants, opt => opt.Items["userId"] = userId);

			return model;
		}

		public async Task<IEnumerable<T>> Pagination<T>(IEnumerable<T> model, int page)
		{
			var plants = model
				.Skip((page - 1) * ItemsPerPage)
				.Take(ItemsPerPage)
				.ToList();

			return plants;
		}

		public async Task EditAsync(int id, PlantEditOrAddViewModel model)
		{
			var plant = await _repository
				.All<Plant>()
				.Include(x => x.Pets)
				.FirstOrDefaultAsync(x => x.Id == id);

			if (plant == null)
			{
				throw new NotFoundException();
			}

			model.ImageUrl = plant.ImageUrl;
			_mapper.Map(model, plant);

			var petIds = model.PetIds;

			var pets = await _repository
					.All<Pet>()
					.Where(x => petIds.Contains(x.Id))
					.ToListAsync();

			plant.Pets = pets;

			_repository.Update(plant);
			await _repository.SaveChangesAsync();
		}

		public async Task LikeButton(int id, bool isLiked, string userId)
		{
			var plant = await _repository.FindByIdAsync<Plant>(id);
			var user = await _repository.All<ApplicationUser>()
										.Include(x => x.LikedPlants)
										.SingleOrDefaultAsync(x => x.Id == userId);

			if (plant == null || user == null)
			{
				throw new NotFoundException();
			}

			var likedPlant = user.LikedPlants
				.FirstOrDefault(x => x.Id == plant.Id);

			if (isLiked && likedPlant == null)
			{
				user.LikedPlants.Add(plant);
			}
			else
			{
				user.LikedPlants.Remove(plant);
			}

			await _repository.SaveChangesAsync();
		}

		private BlobClient GetBlobClient(string fileName)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
			return blobContainerClient.GetBlobClient(fileName);
		}

		private Humidity? HumidityFromPercentage(double? percentage)
		{
			if (percentage == null)
			{
				return null;
			}
			else if (percentage >= 0 && percentage <= 25)
			{
				return Humidity.Low;
			}
			else if (percentage > 25 && percentage <= 50)
			{
				return Humidity.Moderate;
			}
			else if (percentage > 50 && percentage <= 75)
			{
				return Humidity.High;
			}
			else
			{
				return Humidity.VeryHigh;
			}
		}
	}
}
