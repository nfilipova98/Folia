namespace Plants.Controllers
{
	using Data.Models.Plant;
	using Models;
	using Services.APIs.BlobService;
	using Services.PlantService;
	using Services.RepositoryService;
	using Utilities;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;

    public class PlantController : BaseController
	{
		private readonly IRepository _repository;
		private readonly IPlantService _plantService;

		public PlantController(IRepository repository, IPlantService plantService)
		{
			_repository = repository;
			_plantService = plantService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Favorites()
		{
			var model = new List<PlantEditOrAddViewModel>();

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> Favorites(PlantEditOrAddViewModel model)
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Select(x => new PlantEditOrAddViewModel
				{
					Name = model.Name,
					ScientificName = model.ScientificName,
					Lifestyle = model.Lifestyle,
					Outdoor = model.Outdoor,
					Difficulty = model.Difficulty,
					Humidity = model.Humidity,
					IsTrending = model.IsTrending,
					KidSafe = model.KidSafe
				})
				.OrderBy(x => x.Id)
				.ToListAsync();

			return View(plants);
		}

		[AllowAnonymous]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public IActionResult MyPlants()
		{
			return View();
		}

		[AllowAnonymous]
		public async Task<IActionResult> Explore()
		{
			var model = await _repository
				.AllReadOnly<Plant>()
				.ToListAsync();

			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Add()
		{
			var model = new PlantEditOrAddViewModel();

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Add(PlantEditOrAddViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			TempData["PlantInfo"] = JsonConvert.SerializeObject(model);

			return RedirectToAction(nameof(UploadFile), new { fromAddAction = true });
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult UploadFile(bool? fromAddAction)
		{
			if (fromAddAction != true)
			{
				return NotFound();
			}

			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> UploadFile(ImageModel file)
		{
			if (file == null || file.FormFile == null || file.FormFile.Length == 0)
			{
				ModelState.AddModelError("Image", "Please upload an image.");
				return View();
			}

			var model = JsonConvert.DeserializeObject<PlantEditOrAddViewModel>(TempData["PlantInfo"].ToString());

			if (model == null)
			{
				return NotFound();
			}

			var fileName = Guid.NewGuid().ToString();
			using var fileStream = file.FormFile.OpenReadStream();
			var fileUrl = await _plantService.UploadFileAsync(file, model.Id);

			if (fileUrl == string.Empty)
			{

			}

			var plant = new Plant()
			{
				Id = model.Id,
				Name = model.Name,
				ScientificName = model.ScientificName,
				Difficulty = model.Difficulty,
				KidSafe = model.KidSafe,
				Outdoor = model.Outdoor,
				Humidity = model.Humidity,
				IsTrending = false,
				Lifestyle = model.Lifestyle,
				ImageUrl = fileUrl,
			};

			await _repository.AddAsync(plant);
			await _repository.SaveChangesAsync();

			return RedirectToAction("Home", "Index");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Edit(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			if (plant == null)
			{
				return NotFound();
			}

			var model = new PlantEditOrAddViewModel()
			{
				Name = plant.Name,
				ScientificName = plant.ScientificName,
				Lifestyle = plant.Lifestyle,
				Outdoor = plant.Outdoor,
				Difficulty = plant.Difficulty,
				Humidity = plant.Humidity,
				IsTrending = plant.IsTrending,
				KidSafe = plant.KidSafe
			};

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Edit(PlantEditOrAddViewModel model, int id)
		{
			var plantToEdit = await _repository
				.FindByIdAsync<Plant>(id);

			if (plantToEdit == null)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//vij za pets

			plantToEdit.Name = model.Name;
			plantToEdit.ScientificName = model.ScientificName;
			plantToEdit.Lifestyle = model.Lifestyle;
			plantToEdit.Outdoor = model.Outdoor;
			plantToEdit.Difficulty = model.Difficulty;
			plantToEdit.Humidity = model.Humidity;
			plantToEdit.IsTrending = model.IsTrending;
			plantToEdit.KidSafe = model.KidSafe;

			await _repository.SaveChangesAsync();

			return RedirectToAction("Home", "Index");
		}

		[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			if (plant == null)
			{
				return NotFound();
			}

			var model = new PlantDeleteViewModel
			{
				Id = plant.Id,
				Name = plant.Name
			};

			return View(model);
		}

		[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var plant = await _repository
				.FindByIdAsync<Plant>(id);

			if (plant == null)
			{
				return NotFound();
			}

			//_repository..Remove(plant);
			await _repository.SaveChangesAsync();

			return RedirectToAction();
		}
	}
}
