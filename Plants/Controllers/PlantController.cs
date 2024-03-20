namespace Plants.Controllers
{
	using Models;
	using Services.APIs.Models;
	using Services.PetService;
	using Services.PlantService;
	using static Services.Constants.GlobalConstants.Paging;
	using Utilities;
	using ViewModels;

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
		public async Task<IActionResult> Favorites(int id = 1)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (userId == null)
			{
				return View("NoPlantsInFavorites");
			}

			var plants = await _plantService.GetFavoritePlantsAsync<PlantAllViewModel>(userId, id, ItemsPerPage);

			if (plants.Any())
			{
				var model = new PlantsAllViewModel
				{
					PageNumber = id,
					AllPlants = plants,
					ItemsPerPage = ItemsPerPage,
					ItemsCount = await _plantService.GetPlantsCount()
				};

				return View(model);
			}

			return View("NoPlantsInFavorites");
		}

		[AllowAnonymous]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public IActionResult MyPlants()
		{
			return View();
		}

		[AllowAnonymous]
		public async Task<IActionResult> Explore(int id = 1)
		{
			var model = new PlantsAllViewModel
			{
				PageNumber = id,
				AllPlants = await _plantService.GetAllPlantsAsync<PlantAllViewModel>(id, ItemsPerPage),
				ItemsPerPage = ItemsPerPage,
				ItemsCount = await _plantService.GetPlantsCount()
			};

			return View(model);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add()
		{
			var model = new PlantEditOrAddViewModel();
			model.Pets = await _petService.GetAllPetsAsync();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		//vij dali da e asinhronno
		public async Task<IActionResult> Add(PlantEditOrAddViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Pets = await _petService.GetAllPetsAsync();
				return View(model);
			}

			TempData["PlantInfo"] = JsonConvert.SerializeObject(model);

			return RedirectToAction(nameof(UploadFile));
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult UploadFile()
		{
			if (TempData["PlantInfo"] == null)
			{
				return BadRequest();
			}

			TempData.Keep("PlantInfo");

			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UploadFile(ImageModel file)
		{
			if (file == null || file.FormFile == null || file.FormFile.Length == 0
				|| !file.FormFile.ContentType.StartsWith("image"))
			{
				ModelState.AddModelError(nameof(ImageModel.FormFile), "Please upload an image.");
				return View();
			}

			var model = JsonConvert.DeserializeObject<PlantEditOrAddViewModel>(TempData["PlantInfo"].ToString());

			if (model == null)
			{
				return NotFound();
			}

			var url = await _plantService.UploadFileAsync(file);
			await _plantService.CreatePlantAsync(url, model);

			return RedirectToAction(nameof(Explore));
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id)
		{
			var plant = await _plantService.ExistsAsync(id);

			if (plant == false)
			{
				return BadRequest();
			}

			var model = await _plantService.GetPlantAddOrEditModelAsync(id);

			model.Pets = await _petService.GetAllPetsAsync();
			model.PetIds = await _plantService.GetPetIds(id);

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(PlantEditOrAddViewModel model, int id)
		{
			var plantToEdit = await _plantService.ExistsAsync(id);

			if (plantToEdit == false)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				model.Pets = await _petService.GetAllPetsAsync();
				model.PetIds = await _plantService.GetPetIds(id);
				return View(model);
			}

			await _plantService.EditAsync(id, model);

			return RedirectToAction(nameof(Explore));
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var plant = await _plantService.DeleteAsync(id);

			return View(plant);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var plant = await _plantService.DeleteAsync(id);
			var url = plant.ImageUrl;
			var result = await _plantService.DeleteFileAsync(url, id);

			if (result == false)
			{

			}

			return RedirectToAction(nameof(Explore));
		}
	}
}
