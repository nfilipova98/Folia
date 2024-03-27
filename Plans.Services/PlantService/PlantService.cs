namespace Plants.Services.PlantService
{
	using APIs.Models;
	using Data.Models.ApplicationUser;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using Models;
	using RepositoryService;
	using static Constants.GlobalConstants.ApiConstants;

	using AutoMapper;
	using Azure;
	using Azure.Storage.Blobs;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;

	public class PlantService : IPlantService
	{
		private readonly IRepositoryService _repository;
		private readonly IMapper _mapper;
		private readonly BlobServiceClient _blobServiceClient;

		public PlantService(IRepositoryService repository, IMapper mapper, BlobServiceClient blobServiceClient)
		{
			_repository = repository;
			_mapper = mapper;
			_blobServiceClient = blobServiceClient;
		}

		//vij za greshkite kak se pravi

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
			try
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
			catch (RequestFailedException ex)
			{
				throw;
			}
		}

		public async Task CreatePlantAsync(string fileUrl, PlantEditOrAddViewModel model)
		{
			var petIds = model.PetIds;

			var pets = await _repository.AllReadOnly<Pet>()
				.Where(x => petIds.Contains(x.Id))
				.ToListAsync();

			var plant = _mapper.Map<Plant>(model);
			plant.ImageUrl = fileUrl;

			await _repository.AddAsync(plant);
			await _repository.SaveChangesAsync();

			if (pets.Count != 0)
			{
				foreach (var item in pets)
				{
					plant.Pets.Add(item);
				}

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<PlantDeleteViewModel> DeleteAsync(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			return _mapper.Map<PlantDeleteViewModel>(plant);
		}

		public async Task<bool> DeleteFileAsync(string url, int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			var fileName = Path.GetFileName(url);

			if (fileName == null || plant == null)
			{

			}

			var blobClient = GetBlobClient(fileName);
			var isDeleted = await blobClient.DeleteIfExistsAsync();

			_repository.Delete<Plant>(plant);
			await _repository.SaveChangesAsync();

			return isDeleted;
		}

		public async Task<IEnumerable<int>> GetPetIds(int id)
		{
			var petIds = _repository
				.AllReadOnly<Plant>()
				.Where(plant => plant.Id == id)
				.SelectMany(plant => plant.Pets.Select(pet => pet.Id))
				.ToList();

			return petIds;
		}

		//improve this code
		public async Task<IEnumerable<PlantAllViewModel>> GetAllPlantsAsync<T>
			(int page,
			int itemsPerPage,
			string userId,
			string searchString)
		{

			var plantsToShow = _repository.AllReadOnly<Plant>();

			if (searchString != string.Empty)
			{
				string normalizedSearchTerm = searchString.ToLower();

				plantsToShow = plantsToShow
				   .Where(x => x.Name.ToLower().Contains(normalizedSearchTerm) ||
									  x.ScientificName.ToLower().Contains(normalizedSearchTerm));
			}

			var plants = await plantsToShow
				.Include(x => x.UsersLikedPlant)
				.OrderByDescending(x => x.Id)
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
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

		public async Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync<T>(string id, int page, int itemsPerPage, string userId)
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Include(x => x.UsersLikedPlant)
				.Where(x => x.UsersLikedPlant.Any(x => x.Id == id))
				.OrderByDescending(x => x.Id)
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.ToListAsync();

			var model = _mapper.Map<List<Plant>, List<PlantAllViewModel>>(plants, opt => opt.Items["userId"] = userId);

			return model;
		}

		public async Task EditAsync(int id, PlantEditOrAddViewModel model)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			var pets = _mapper.Map<Pet>(model.Pets);

			//vij za jivotnite
			if (plant != null)
			{
				plant.Name = model.Name;
				plant.ScientificName = model.ScientificName;
				plant.Lifestyle = model.Lifestyle;
				plant.Outdoor = model.Outdoor;
				plant.Difficulty = model.Difficulty;
				plant.Humidity = model.Humidity;
				plant.IsTrending = model.IsTrending;
				plant.KidSafe = model.KidSafe;
				//plant.Pets = pets;
			}

			_repository.UpdateAsync<Plant>(plant);
			await _repository.SaveChangesAsync();
		}

		private BlobClient GetBlobClient(string fileName)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
			return blobContainerClient.GetBlobClient(fileName);
		}

		public async Task<int> GetPlantsCount()
		{
			var plant = await _repository.AllReadOnly<Plant>()
				.ToListAsync();

			return plant.Count;
		}

		public async Task<bool> LikeButton(int id, bool isLiked, string userId)
		{
			var plant = await _repository.FindByIdAsync<Plant>(id);
			var user = await _repository.All<ApplicationUser>()
										.Include(x => x.LikedPlants)
										.SingleOrDefaultAsync(x => x.Id == userId);

			if (plant == null || user == null)
			{
				return false;
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

			return true;
		}
	}
}
