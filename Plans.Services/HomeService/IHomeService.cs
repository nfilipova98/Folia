namespace Plants.Services.HomeService
{
	using Microsoft.AspNetCore.Mvc;

	public interface IHomeService
	{
		Task<IActionResult> LikeButton(int id, bool isLiked, string userId);
	}
}
