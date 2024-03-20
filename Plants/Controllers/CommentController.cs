namespace Plants.Controllers
{
	using Services.CommentService;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	public class CommentController : Controller
	{
		private ICommentService _service;

		public CommentController(ICommentService service)
		{
			_service = service;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var comments = await _service.GetCommentsAsync();

			return View(comments);
		}

		//	[TypeFilter(typeof(TierResultFilterAttribute))] sloji go kato ostavqt komentari
	}
}
