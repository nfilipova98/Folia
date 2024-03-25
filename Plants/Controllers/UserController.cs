namespace Plants.Controllers
{
	using ViewModels;
	using Services.UserService;

	using Microsoft.AspNetCore.Mvc;

	public class UserController : BaseController
	{
		private IUserService _service;

		[HttpGet]
		public IActionResult FirstLoginView()
		{
			var model = new FirstLoginViewModel();

			return View(model);
		}

		[HttpPost]
		//vij dali da e asinhronno
		public async Task<IActionResult> FirstLoginView(FirstLoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _service.GetModels();

			return RedirectToAction("Index", "Home");
		}
	}
}
