namespace Plants.Controllers
{
	using Services.PetService;
	using static Services.Constants.GlobalConstants.AdminConstants;
	using ViewModels;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class PetController : BaseController
	{
		private readonly IPetService _petService;
		private readonly ILogger _logger;

		public PetController(IPetService petService, ILogger<PetController> logger)
		{
			_petService = petService;
			_logger = logger;
		}

		[HttpGet]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Add()
		{
			var model = new PetAddViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Add(PetAddViewModel model)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError("PetController/Add - ModelState was not valid");
				return View(model);
			}

			try
			{
				await _petService.CreateAsync(model.Name);
			}
			catch (InvalidOperationException ioEx)
			{
				_logger.LogError(ioEx, "PetController/Add - Pet already exists");
				return BadRequest();
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
