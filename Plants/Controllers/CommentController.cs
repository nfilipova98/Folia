namespace Plants.Controllers
{
    using Utilities;
    using Services.CommentService;
    using ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using SendGrid.Helpers.Errors.Model;

    public class CommentController : BaseController
	{
		private ICommentService _service;
		private ILogger _logger;

		public CommentController(ICommentService service, ILogger<CommentController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Index(int id)
		{
			var comments = new CommentsViewModel();

			try
			{
				comments = await _service.GetCommentsAsync(id);
			}
			catch (NotFoundException nfEx)
			{
				_logger.LogError(nfEx, "CommentController/Index - Plant not found");
				return BadRequest();
			}

			return View(comments);
		}

		[HttpPost]
		[TypeFilter(typeof(TierResultFilterAttribute))]
		public async Task<IActionResult> Index(CommentsViewModel model, int id)
		{
			var userId = User.Id();

			if (!ModelState.IsValid)
			{
				_logger.LogError("CommentController/Index - ModelState was not valid");
				return View(model);
			}

			try
			{
				await _service.AddCommentsAsync(model.NewComment, userId, id);
			}
			catch (ArgumentException aEx)
			{
				_logger.LogError(aEx, "CommentController/Index - Invalid userId or plantId");
				return BadRequest();
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
