namespace Plants.Controllers
{
	using Models;
	using static Services.Constants.GlobalConstants.AdminConstants;
	using Services.PetService;
	using Services.PlantService;
	using Services.RegionService;
	using Utilities;
	using ViewModels;

	using Azure;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Newtonsoft.Json;
	using SendGrid.Helpers.Errors.Model;
	using System.Security.Claims;

	public class PlantController : BaseController
	{
		private readonly IPlantService _plantService;
		private readonly IPetService _petService;
		private readonly IRegionService _regionService;
		private readonly ILogger _logger;

		public PlantController(IPlantService plantService, IPetService petService, IRegionService regionService, ILogger<PlantController> logger)
		{
			_plantService = plantService;
			_petService = petService;
			_regionService = regionService;
			_logger = logger;
		}

		//sloji logger i greshki
		[HttpGet]
		[AllowAnonymous]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> Favorites(int id = 1)
		{
			string userId = User.Id();

			if (userId == null)
			{
				return View("NoPlantsInFavorites");
			}

			var plants = await _plantService.GetFavoritePlantsAsync(userId);

			if (plants.Any())
			{
				var model = new PlantsAllViewModelFavorites
				{
					ItemsCount = plants.Count(),
					PageNumber = id
				};

				var plantsToShow = await _plantService.Pagination(plants, id);

				model.AllPlants = plantsToShow;

				return View(model);
			}

			return View("NoPlantsInFavorites");
		}

		//sloji logger i greshki
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Explore(PlantsAllViewModel model, int id = 1)
		{
			string userId = User.Id();

			var regions = await _regionService.GetAllRegionsAsync();
			var plants = await _plantService.GetAllPlantsAsync
				(userId, 
				model.SearchTerm, 
				model.KidSafe, 
				model.PetSafe, 
				model.Lifestyle, 
				model.Difficulty);

			var plantsToShow = new PlantsAllViewModel
			{
				ItemsCount = plants.Count(),
				PageNumber = id,
				Regions = regions
			};	

			var plantsPagination = await _plantService.Pagination(plants, id);

			plantsToShow.AllPlants = plantsPagination;

			return View(plantsToShow);
		}

		[HttpGet]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Add()
		{
			var model = new PlantEditOrAddViewModel();
			model.Pets = await _petService.GetAllPetsAsync();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Add(PlantEditOrAddViewModel model)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError("PlantController/Add - ModelState was not valid");

				model.Pets = await _petService.GetAllPetsAsync();
				return View(model);
			}

			TempData["PlantInfo"] = JsonConvert.SerializeObject(model);

			return RedirectToAction(nameof(UploadFile));
		}

		[HttpGet]
		[Authorize(Roles = Admin)]
		public IActionResult UploadFile()
		{
			if (TempData["PlantInfo"] == null)
			{
				_logger.LogError("PlantController/UploadFile - TempData was null");
				return BadRequest();
			}

			TempData.Keep("PlantInfo");

			return View();
		}

		[HttpPost]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> UploadFile(ImageModel file)
		{
			var url = string.Empty;

			if (file == null || file.FormFile == null || file.FormFile.Length == 0
				|| !file.FormFile.ContentType.StartsWith("image"))
			{
				_logger.LogError("PlantController/UploadFile - Error occurred during file upload");
				ModelState.AddModelError(nameof(ImageModel.FormFile), "Please upload an image.");
				return View();
			}

			var model = JsonConvert.DeserializeObject<PlantEditOrAddViewModel>(TempData["PlantInfo"].ToString());

			if (model == null)
			{
				_logger.LogError("PlantController/UploadFile - No model was found");
				return NotFound();
			}

			try
			{
				url = await _plantService.UploadFileAsync(file);
			}
			catch (RequestFailedException ex)
			{
				_logger.LogError(ex, "PlantController/UploadFile - Azure request failed error");
				return BadRequest();
			}

			await _plantService.CreatePlantAsync(url, model);
			return RedirectToAction(nameof(Explore));
		}

		[HttpGet]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Edit(int id)
		{
			var plant = await _plantService.ExistsAsync(id);

			if (plant == false)
			{
				_logger.LogError("PlantController/Edit - No plant with the given id exists");
				return BadRequest();
			}

			var model = await _plantService.GetPlantAddOrEditModelAsync(id);

			model.Pets = await _petService.GetAllPetsAsync();
			model.PetIds = await _plantService.GetPetIds(id);

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Edit(PlantEditOrAddViewModel model, int id)
		{
			var plantToEdit = await _plantService.ExistsAsync(id);

			if (plantToEdit == false)
			{
				_logger.LogError("PlantController/Edit - No plant with the given id exists");
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				_logger.LogError("PlantController/Edit - ModelState was not valid");

				model.Pets = await _petService.GetAllPetsAsync();
				model.PetIds = await _plantService.GetPetIds(id);
				return View(model);
			}

			try
			{
				await _plantService.EditAsync(id, model);
			}
			catch (NotFoundException nfEx)
			{
				_logger.LogError(nfEx, "PlantController/Edit - Plant with the given id was not found");
				return NotFound();
			}

			return RedirectToAction(nameof(Explore));
		}

		[HttpGet]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var plant = await _plantService.DeleteAsync(id);
				return View(plant);
			}
			catch (NotFoundException nfEx)
			{
				_logger.LogError(nfEx, "PlantController/Delete - Plant with the given id was not found");
				return NotFound();
			}
		}

		[HttpPost]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var url = string.Empty;

			try
			{
				var plant = await _plantService.DeleteAsync(id);
				url = plant.ImageUrl;

				await _plantService.DeleteFileAsync(url, id);
			}
			catch (NotFoundException nfEx)
			{
				_logger.LogError(nfEx, "PlantController/DeleteConfirmed - Plant with the given id was not found");
				return NotFound();
			}
			catch (ArgumentException argEx)
			{
				_logger.LogError(argEx, "PlantController/DeleteConfirmed - File with the given name was not found");
				return BadRequest();
			}
			catch (RequestFailedException rEx)
			{
				_logger.LogError(rEx, "PlantController/DeleteConfirmed - The file was not deleted");
				return BadRequest();
			}

			return RedirectToAction(nameof(Explore));
		}

		[HttpPost]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> LikeButton(int id, bool isLiked)
		{
			var userId = User.Id();

			if (userId == null)
			{
				return BadRequest();
			}

			try
			{
				await _plantService.LikeButton(id, isLiked, userId);
			}
			catch (NotFoundException nfEx)
			{
				_logger.LogError(nfEx, "PlantController/LikeButton - Error occurred while trying to like a plant");
				return BadRequest();
			}

			return Ok();
		}
	}
}
