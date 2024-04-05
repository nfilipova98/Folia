namespace Plants.Services.CommentService
{
	using Models;
	using ViewModels;

	public interface ICommentService
	{
		Task<CommentsViewModel> GetCommentsAsync(int id);
		Task<CommentViewModel> AddCommentsAsync(CommentViewModel model, string id, int plantId);
	}
}
