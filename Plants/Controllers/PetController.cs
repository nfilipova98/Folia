namespace Plants.Controllers
{
	using Models;
	using Services.PetService;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Plants.ViewModels;

	public class PetController : BaseController
	{
		private readonly IPetService _petService;

		public PetController(IPetService petService)
		{
			_petService = petService;
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add()
		{
			var model = new PetViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		//vij dali da e asinhronno
		public async Task<IActionResult> Add(PetViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _petService.CreateAsync(model.Name);

			return RedirectToAction("Index", "Home");
		}
	}
}
