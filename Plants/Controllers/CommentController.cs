namespace Plants.Controllers
{
	using Services.RepositoryService;

	using Microsoft.AspNetCore.Mvc;

	public class CommentController : Controller
	{
		private IRepository _repository;

		public CommentController(IRepository repository)
		{
			_repository = repository;
		}

		//[AllowAnonymous]
		//public async Task<IActionResult> Index()
		//{
		//	var comments = await _repository.AllReadOnly<Comment>()
		//		.Select(x => new CommentViewModel
		//		{
		//	
		//		})
		//		.OrderBy(x => x.Id)
		//		.ToListAsync();
		//
		//	return View(comments);
		//}
	}
}
