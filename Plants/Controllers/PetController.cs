namespace Plants.Controllers
{
	using Models;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class PetController : BaseController
	{
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

			return RedirectToAction("Index", "Home");
		}
	}
}
