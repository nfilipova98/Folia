namespace Plants.Models
{
	using static Services.Constants.GlobalConstants.CommentConstants;
	using static Services.Constants.GlobalConstants.ErrorMessages;

	using System.ComponentModel.DataAnnotations;

	public class CommentViewModel
	{
		public int Id { get; set; }

		[StringLength(CommentContentMaxLenght, MinimumLength = CommentContentMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public required string Content { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required string UserId { get; set; }

		public string? UserPictureUrl { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required int PlantId { get; set; }
	}
}