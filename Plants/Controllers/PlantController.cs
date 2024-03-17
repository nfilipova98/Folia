namespace Plants.Controllers
{
    using Models;
    using Services.APIs.Models;
	using Services.PetService;
    using Services.PlantService;
    using Utilities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
	using System.Security.Claims;

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
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> Favorites()
		{
			var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var plants = await _plantService.GetFavoritePlantsAsync(id);

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
			//mahni id posle 
			var plants = await _plantService.GetAllPlantsAsync();

			return View(plants);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Add()
		{
			var model = new PlantEditOrAddViewModel();
			model.Pets = await _petService.GetAllPetsAsync();

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

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Edit(int id)
		{
			var plant = await _plantService.ExistsAsync(id);

			if (plant == false)
			{
				return BadRequest();
			}

			var model = await _plantService.GetPlantAddOrEditModelAsync(id);

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Edit(PlantEditOrAddViewModel model, int id)
		{
			var plantToEdit = await _plantService.ExistsAsync(id);

			if (plantToEdit == false)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _plantService.EditAsync(id, model);

			return RedirectToAction("Explore");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Delete(int id)
		{
			var plant = await _plantService.DeleteAsync(id);

			return View(plant);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var plant = await _plantService.DeleteAsync(id);
			var url = plant.ImageUrl;
			var result = await _plantService.DeleteFileAsync(url, id);

			if (result == false)
			{

			}

			return RedirectToAction("Explore");
		}
	}
}
