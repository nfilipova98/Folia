namespace Plants.Controllers
{
	using Models;
	using Services.HomeService;
	using Services.PlantService;
	using Utilities;

	using System.Diagnostics;
	using System.Security.Claims;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class HomeController : BaseController
	{
		private IHomeService _homeService;
		private IPlantService _plantService;

		public HomeController(IHomeService homeService, IPlantService plantService)
		{
			_homeService = homeService;
			_plantService = plantService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var plants = await _plantService.GetTrendingPlants();

			return View(plants);
		}

		[AllowAnonymous]
		[HttpPost]
		//add authorize
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> LikeButton(int id, bool isLiked)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
			await _homeService.LikeButton(id, isLiked, userId);

			return Ok();
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
