namespace Plants.Services.CommentService
{
    using ViewModels;

    public interface ICommentService
	{
		Task<CommentsViewModel> GetCommentsAsync(int id);
		Task AddCommentsAsync(CommentModel model, string id, int plantId);
	}
}
