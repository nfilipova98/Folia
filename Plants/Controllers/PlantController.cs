namespace Plants.Controllers
{
    using Models;
    using Services.APIs.Models;
	using Services.Pet;
    using Services.PlantService;
    using Utilities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

	public class PlantController : BaseController
	{
		private readonly IPlantService _plantService;
		private readonly IPetService _petService;

		public PlantController(IPlantService plantService, IPetService petService)
		{
			_plantService = plantService;
			_petService = petService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Favorites()
		{
			var model = new List<PlantHomeViewModel>();

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> Favorites(PlantHomeViewModel model)
		{
			var plants = await _plantService.GetAllPlantsAsync();

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
			var plants = await _plantService.GetFavoritePlantsAsync();

			return View(plants);
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
		//vij dali da e asinhronno
		public async Task<IActionResult> Add(PlantEditOrAddViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			TempData["PlantInfo"] = JsonConvert.SerializeObject(model);

			return RedirectToAction(nameof(UploadFile));
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult UploadFile()
		{
			if (TempData["PlantInfo"] == null)
			{
				return BadRequest();
			}

			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> UploadFile(ImageModel file)
		{
			if (file == null || file.FormFile == null || file.FormFile.Length == 0 || !file.FormFile.ContentType.StartsWith("image"))
			{
				ModelState.AddModelError(nameof(ImageModel.FormFile), "Please upload an image.");
				return View();
			}

			var model = JsonConvert.DeserializeObject<PlantEditOrAddViewModel>(TempData["PlantInfo"].ToString());

			if (model == null)
			{
				return NotFound();
			}

			await _plantService.UploadFileAsync(file, model);

			return RedirectToAction("Index", "Home");
		}

		//[HttpGet]
		//[AllowAnonymous]
		//public async Task<IActionResult> Edit(int id)
		//{
		//	var plant = await _repository
		//		.FindByIdAsync<Plant>(id);

		//	if (plant == null)
		//	{
		//		return NotFound();
		//	}

		//	var model = new PlantEditOrAddViewModel()
		//	{
		//		Name = plant.Name,
		//		ScientificName = plant.ScientificName,
		//		Lifestyle = plant.Lifestyle,
		//		Outdoor = plant.Outdoor,
		//		Difficulty = plant.Difficulty,
		//		Humidity = plant.Humidity,
		//		IsTrending = plant.IsTrending,
		//		KidSafe = plant.KidSafe
		//	};

		//	return View(model);
		//}

		//[HttpPost]
		//[AllowAnonymous]
		//public async Task<IActionResult> Edit(PlantEditOrAddViewModel model, int id)
		//{
		//	var plantToEdit = await _repository
		//		.FindByIdAsync<Plant>(id);

		//	if (plantToEdit == null)
		//	{
		//		return NotFound();
		//	}

		//	if (!ModelState.IsValid)
		//	{
		//		return View(model);
		//	}

		//	//vij za pets

		//	plantToEdit.Name = model.Name;
		//	plantToEdit.ScientificName = model.ScientificName;
		//	plantToEdit.Lifestyle = model.Lifestyle;
		//	plantToEdit.Outdoor = model.Outdoor;
		//	plantToEdit.Difficulty = model.Difficulty;
		//	plantToEdit.Humidity = model.Humidity;
		//	plantToEdit.IsTrending = model.IsTrending;
		//	plantToEdit.KidSafe = model.KidSafe;

		//	await _repository.SaveChangesAsync();

		//	return RedirectToAction("Home", "Index");
		//}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Delete(int id)
		{
			var plant = await _plantService.DeleteAsync(id);

			return View(plant);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> DeleteConfirmed(ImageModel file, int id)
		{
			var plant = await _plantService.DeleteAsync(id);
			var result = await _plantService.DeleteFileAsync(file, id);

			if (result == false)
			{

			}

			return RedirectToAction();
		}
	}
}
