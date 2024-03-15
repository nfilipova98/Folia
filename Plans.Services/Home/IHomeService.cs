namespace Plants.Services.Home
{
	using Models;

	using Microsoft.AspNetCore.Mvc;

	public interface IHomeService
	{
		Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants();
		Task<IActionResult> LikeButton(int id, bool isLiked, string userId);
	}
}
