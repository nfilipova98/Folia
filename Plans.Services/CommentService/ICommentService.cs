namespace Plants.Services.CommentService
{
	using Models;

	public interface ICommentService
	{
		Task<IEnumerable<CommentViewModel>> GetCommentsAsync();
	}
}
