namespace Plants.Controllers
{
	using Services.CityService;
	using static Services.Constants.GlobalConstants.AdminConstants;
	using ViewModels;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class CityController : BaseController
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}

		[HttpGet]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Add()
		{
			var model = new CityAddViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = Admin)]
		public async Task<IActionResult> Add(CityAddViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _cityService.CreateAsync(model.CityName, model.CountryName);

			return RedirectToAction("Index", "Home");
		}
	}
}
