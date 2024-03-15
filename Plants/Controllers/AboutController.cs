namespace Plants.Controllers
{
	using Services.AboutService;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class AboutController : BaseController
	{
		private IAboutService _countsService;

		public AboutController(IAboutService countsService)
		{
			_countsService = countsService;
		}

		[AllowAnonymous]
		//vij dali trqbva da e async
		public async Task<IActionResult> Index()
		{
			var data = _countsService.GetCounts();

			return View(data);
		}
	}
}
