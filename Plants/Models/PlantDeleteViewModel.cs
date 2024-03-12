namespace Plants.Models
{
    using static Services.Constants.GlobalConstants.ErrorMessages;

    using System.ComponentModel.DataAnnotations;

    public class PlantDeleteViewModel
	{
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
