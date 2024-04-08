namespace Plants.ViewModels
{
	using Models;

	public class CommentsViewModel
	{
		public List<CommentViewModel?> ExistingComments { get; set; } = new List<CommentViewModel?>();

		public CommentModel NewComment { get; set; } = null!;

		public string PlantDescription { get; set; } = string.Empty;

		public string PlantName { get; set; } = string.Empty;
	}
}
