namespace Plants.Controllers
{
	using Models;
	using Services.PlantService;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics;
	using System.Security.Claims;

	public class HomeController : BaseController
	{
		private IPlantService _plantService;

		public HomeController(IPlantService plantService)
		{
			_plantService = plantService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var userId = User.Id();
			var plants = await _plantService.GetTrendingPlants(userId);

			return View(plants);
		}

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 404)
			{
				return View("404");
			}
			if (statusCode == 500)
			{
				return View("500");
			}

			return this.View(
				new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}
	}
}
