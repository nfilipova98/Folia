namespace Plants.Services.PlantService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using Models;
	using RepositoryService;
	using static Constants.GlobalConstants.ApiConstants;
	using static Services.Constants.GlobalConstants.Paging;

	using AutoMapper;
	using Azure.Storage.Blobs;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using SendGrid.Helpers.Errors.Model;
	using Plants.ViewModels;
	using Plants.Data.Models.Enums;

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

		public async Task<IEnumerable<int>> GetPetIds(int id)
		{
			var petIds = _repository
				.AllReadOnly<Plant>()
				.Where(plant => plant.Id == id)
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
			Difficulty? difficulty)
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
			if (searchString != null)
			{
				string normalizedSearchTerm = searchString.ToLower();

				plantsToShow = plantsToShow
				   .Where(x => x.Name.ToLower().Contains(normalizedSearchTerm) ||
									  x.ScientificName.ToLower().Contains(normalizedSearchTerm) ||
									  x.Description.ToLower().Contains(normalizedSearchTerm));
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
				.FindByIdAsync<Plant>(id);

			if (plant == null)
			{
				throw new NotFoundException();
			}

			_repository.UpdateAsync(plant);
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
	}
}
