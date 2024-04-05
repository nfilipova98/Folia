namespace Plants.Models
{
	using static Services.Constants.GlobalConstants.CommentConstants;
	using static Services.Constants.GlobalConstants.ErrorMessages;

	using System.ComponentModel.DataAnnotations;

	public class CommentViewModel
	{
        [StringLength(CommentContentMaxLenght, MinimumLength = CommentContentMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public string Content { get; set; } = string.Empty;

		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

		public required string ApplicationUserId { get; set; } = string.Empty;
		public required string ApplicationUserName { get; set; } = string.Empty;

		public string? ApplicationUserPictureUrl { get; set; }

		public required int PlantId { get; set; }
	}
}