namespace Plants.Controllers
{
	using Models;
	using Services.Home;
	using Utilities;

	using System.Diagnostics;
	using System.Security.Claims;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Plants.Data.Models.ApplicationUser;

	public class HomeController : BaseController
	{
		private IHomeService _service;

		public HomeController(IHomeService service)
		{
			_service = service;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var plants = await _service.GetTrendingPlants();

			return View(plants);
		}

		[AllowAnonymous]
		[HttpPost]
		//add authorize
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> LikeButton(int id, bool isLiked)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
			await _service.LikeButton(id, isLiked, userId);

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
