namespace Plants.Models
{
	using Data.Models.Enums;
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.PlantConstants;

	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel;

	public class PlantAllViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		public required int Id { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(PlantNameMaxLenght, MinimumLength = PlantNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public required string Name { get; set; } = string.Empty;

		[StringLength(PlantScientificNameMaxLenght, MinimumLength = PlantScientificNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		[DisplayName("Scientific Name")]
		public string? ScientificName { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required Humidity Humidity { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required Difficulty Difficulty { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required Lifestyle Lifestyle { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[DisplayName("Kid Safe")]
		public required bool KidSafe { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required bool Outdoor { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[DisplayName("Is Trending")]
		public required bool IsTrending { get; set; }

		public string? ImageUrl { get; set; }

		public ICollection<PetViewModel>? Pets { get; set; }

		public ICollection<CommentViewModel>? Comments { get; set; }
	}
}
