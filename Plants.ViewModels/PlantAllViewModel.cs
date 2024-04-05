namespace Plants.Models
{
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.PlantConstants;

	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel;

	public class PlantAllViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(PlantNameMaxLenght, MinimumLength = PlantNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[StringLength(PlantScientificNameMaxLenght, MinimumLength = PlantScientificNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		[DisplayName("Scientific Name")]
		public string? ScientificName { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[DisplayName("Is Trending")]
		public bool IsTrending { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required string Description { get; set; } = string.Empty;

		public string? ImageUrl { get; set; }

		public bool IsLiked { get; set; }

		public ICollection<CommentViewModel>? Comments { get; set; }
	}
}
