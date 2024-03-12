namespace Plants.Controllers
{
	using Models;

	using Data.Models.ApplicationUser;
	using Data.Models.Plant;
	using Services.RepositoryService;
	using Utilities;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using System.Diagnostics;
	using System.Security.Claims;

	public class HomeController : BaseController
	{
		private IRepository _repository;

		public HomeController(IRepository repository)
		{
			_repository = repository;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Where(x => x.IsTrending == true)
				.Select(x => new PlantHomeViewModel
				{
					Id = x.Id,
					Name = x.Name,
					ScientificName = x.ScientificName,
					ImageUrl = x.ImageUrl
				})
				.OrderBy(x => x.Id)
				.ToListAsync();

			return View(plants);
		}

		[AllowAnonymous]
		[HttpPost]
		//add authorize
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> LikeButton(int id, bool isLiked)
		{
			var plant = await _repository.FindByIdAsync<Plant>(id);
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? string.Empty;
			var user = await _repository.FindByIdAsync<ApplicationUser>(userId);

			if (plant == null || user == null)
			{
				return NotFound();
			}

			var usersPlants = user.LikedPlants
				.FirstOrDefault(x => x.Id == plant.Id);

			if (isLiked && usersPlants == null)
			{
				user.LikedPlants.Add(plant);
			}
			else
			{
				user.LikedPlants.Remove(plant);
			}

			await _repository.SaveChangesAsync();

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
