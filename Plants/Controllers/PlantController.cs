namespace Plants.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class PlantController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Favorites()
		{
			return View();
		}

        [AllowAnonymous]
        public IActionResult MyPlants()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Explore()
        {
            return View();
        }

		[AllowAnonymous]
		public IActionResult Comments()
		{
			return View();
		}
	}
}
