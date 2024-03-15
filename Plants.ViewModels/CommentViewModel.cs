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

		//public required string ApplicationUserId { get; set; }
		//public required ApplicationUser User { get; set; }

		//public required int PlantId { get; set; }
		//public required Plant Plant { get; set; }
	}
}