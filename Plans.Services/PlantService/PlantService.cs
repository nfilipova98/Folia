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

		public async Task<bool> DeleteFileAsync(ImageModel model, int id)
		{
			var filePath = model.ImageUrl;

			var blobClient = GetBlobClient(model.FormFile.FileName);
			var isDeleted = await blobClient.DeleteIfExistsAsync();

			return isDeleted;
		}

		public async Task<IEnumerable<PlantHomeViewModel>> GetAllPlantsAsync()
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.OrderBy(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<PlantHomeViewModel>>(plants);

			return model;
		}

		public async Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync()
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.OrderBy(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<PlantAllViewModel>>(plants);

			return model;
		}

		private BlobClient GetBlobClient(string fileName)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
			return blobContainerClient.GetBlobClient(fileName);
		}
	}
}
