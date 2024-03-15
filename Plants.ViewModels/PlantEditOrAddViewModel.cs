namespace Plants.Models
{
	using Data.Models.Enums;
    using static Services.Constants.GlobalConstants.ErrorMessages;
    using static Services.Constants.GlobalConstants.PlantConstants;

    using System.ComponentModel.DataAnnotations;
	using System.ComponentModel;

	[Serializable]
    public class PlantEditOrAddViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(PlantNameMaxLenght, MinimumLength = PlantNameMinLenght,
            ErrorMessage = StringLenghtErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [StringLength(PlantScientificNameMaxLenght, MinimumLength = PlantScientificNameMinLenght,
            ErrorMessage = StringLenghtErrorMessage)]
        [DisplayName("Scientific Name")]
        public string? ScientificName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public Humidity Humidity { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public Difficulty Difficulty { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public Lifestyle Lifestyle { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[DisplayName("Kid Safe")]
        public bool KidSafe { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public bool Outdoor { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
		[DisplayName("Is Trending")]
		public bool IsTrending { get; set; }

        public string? ImageUrl { get; set; }

		public ICollection<int>? Pets { get; set; }
	}
}
