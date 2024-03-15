namespace Plants.Controllers
{
	using Services.RepositoryService;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	public class CommentController : Controller
	{
		private IRepository _repository;

		public CommentController(IRepository repository)
		{
			_repository = repository;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{

			return View();
		}
	}
}
