namespace Plants.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Newtonsoft.Json;
	using Plants.Models;

	public class PetController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Add()
		{
			var model = new PetViewModel();

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		//vij dali da e asinhronno
		public async Task<IActionResult> Add(PetViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
