namespace Plants.Controllers
{
	using Services.AboutService;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class AboutController : BaseController
	{
		private IAboutService _service;

		public AboutController(IAboutService countsService)
		{
			_service = countsService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var data = _service.GetCounts();

			return View(data);
		}
	}
}
