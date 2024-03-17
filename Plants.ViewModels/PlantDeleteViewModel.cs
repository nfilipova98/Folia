namespace Plants.Models
{
    using static Services.Constants.GlobalConstants.ErrorMessages;

    using System.ComponentModel.DataAnnotations;

    public class PlantDeleteViewModel
	{
        [Required(ErrorMessage = RequiredErrorMessage)]
        public required int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public required string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		public required string ImageUrl { get; set; }
	}
}
