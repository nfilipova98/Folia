namespace Plants.ViewModels
{
	using Models;
	using System.ComponentModel.DataAnnotations;

	public class CommentsViewModel
	{
		public List<CommentViewModel?> ExistingComments { get; set; } = new List<CommentViewModel?>();
		public CommentViewModel NewComment { get; set; } = null!;

		[Required]
		public string PlantDescription { get; set; } = string.Empty;

		[Required]
		public string PlantName { get; set; } = string.Empty;
	}
}
