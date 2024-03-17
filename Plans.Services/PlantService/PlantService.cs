namespace Plants.Services.PlantService
{
	using APIs.Models;
	using Data.Models.Plant;
	using static Constants.GlobalConstants.ApiConstants;
	using Models;
	using RepositoryService;

	using AutoMapper;
	using Azure;
	using Azure.Storage.Blobs;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Mvc;

	public class PlantService : IPlantService
	{
		private readonly IRepository _repository;
		private readonly IMapper _mapper;
		private readonly BlobServiceClient _blobServiceClient;

		public PlantService(IRepository repository, IMapper mapper, BlobServiceClient blobServiceClient)
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

		public async Task<IActionResult> UploadFileAsync(ImageModel file, PlantEditOrAddViewModel model)
		{
			try
			{
				var fileName = Guid.NewGuid().ToString();
				using var fileStream = file.FormFile.OpenReadStream();

				var blobClient = GetBlobClient(file.FormFile.FileName);

				using (var stream = file.FormFile.OpenReadStream())
				{
					await blobClient.UploadAsync(stream);
				}

				var fileUrl = blobClient.Uri.ToString();

				//add pets service for adding 
				var plant = _mapper.Map<Plant>(model);
				plant.ImageUrl = fileUrl;
				plant.IsTrending = false;

				await _repository.AddAsync(plant);
				await _repository.SaveChangesAsync();

				return new OkResult();

			}
			catch (RequestFailedException ex)
			{
				throw;
			}

		}

		public async Task<PlantDeleteViewModel> DeleteAsync(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			if (plant == null)
			{

			}

			return _mapper.Map<PlantDeleteViewModel>(plant);
		}

		public async Task<bool> DeleteFileAsync(string url, int id)
		{
			//iztrii ot bazata 
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			var fileName = Path.GetFileName(url);

			if (fileName == null || plant == null)
			{

			}

			var blobClient = GetBlobClient(fileName);
			var isDeleted = await blobClient.DeleteIfExistsAsync();

			//_repository.Delete<Plant>(plant);
			//await _repository.SaveChangesAsync();

			return isDeleted;
		}

		public async Task<IEnumerable<PlantAllViewModel>> GetAllPlantsAsync()
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.ToListAsync();

			var model = _mapper.Map<List<PlantAllViewModel>>(plants);

			return model;
		}

		public async Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants()
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Where(x => x.IsTrending == true)
				.OrderBy(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<PlantHomeViewModel>>(plants);

			return model;
		}

		public async Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync(string id)
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Where(x => x.UsersLikedPlant.Any(x => x.Id == id))
				.ToListAsync();

			var model = _mapper.Map<List<PlantAllViewModel>>(plants);

			return model;
		}

		public async Task EditAsync(int id, PlantEditOrAddViewModel model)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

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
			}

			_repository.UpdateAsync<Plant>(plant);
			await _repository.SaveChangesAsync();
		}

		private BlobClient GetBlobClient(string fileName)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
			return blobContainerClient.GetBlobClient(fileName);
		}
	}
}
