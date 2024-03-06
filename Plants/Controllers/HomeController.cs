namespace Plants.Controllers
{
	using Models;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics;

	public class HomeController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
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
