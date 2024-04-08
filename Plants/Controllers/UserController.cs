namespace Plants.Controllers
{
	using Models;
	using Services.CityService;
	using Services.PetService;
	using Services.UserService;
	using ViewModels;

	using Azure;
	using Microsoft.AspNetCore.Mvc;
	using System.Security.Claims;

	public class UserController : BaseController
	{
		private IUserService _service;
		private IPetService _petService;
		private ICityService _cityService;
		private ILogger _logger;

		public UserController(IUserService service, IPetService petService, ICityService cityService, ILogger<UserController> logger)
		{
			_service = service;
			_petService = petService;
			_cityService = cityService;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult FirstLoginView()
		{
			var model = new FirstLoginViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> FirstLoginView(FirstLoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _service.GetModels();

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> ProfileSetup()
		{
			var model = await _service.GetModels();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ProfileSetup(FirstLoginViewModel model)
		{
			var userId = User.Id();
			var url = string.Empty;

			model.ApplicationUserId = userId;

			if (!ModelState.IsValid)
			{
				_logger.LogError("UserController/ProfileSetup - ModelState was not valid");
				model.Pets = await _petService.GetAllPetsAsync();
				model.Cities = await _cityService.GetAllCitiesAsync();
				
				return View(model);
			}

			var file = model.ImageModel.FormFile;

			//zashto ne izliza validation errora
			if (!file.ContentType.StartsWith("image"))
			{
				_logger.LogError("UserController/ProfilePicture - Error occurred during file upload");
				model.Pets = await _petService.GetAllPetsAsync();
				model.Cities = await _cityService.GetAllCitiesAsync();

				ModelState.AddModelError(nameof(ImageModel.FormFile), "Please upload an image.");
				return View(model);
			}

			try
			{
				url = await _service.UploadFileAsync(model.ImageModel);
			}
			catch (RequestFailedException ex)
			{
				_logger.LogError(ex, "PlantController/UploadFile - Azure request failed error");
				return BadRequest();
			}

			try
			{
				await _service.AddUserInformation(model, url, userId);
			}
			catch (Exception)
			{

				throw;
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
