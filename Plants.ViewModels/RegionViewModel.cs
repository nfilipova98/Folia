namespace Plants.ViewModels
{
    using static Services.Constants.GlobalConstants.ErrorMessages;
    using static Services.Constants.GlobalConstants.RegionConstants;

    using System.ComponentModel.DataAnnotations;

    public class RegionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RegionNameMaxLenght, MinimumLength = RegionNameMinLenght,
            ErrorMessage = StringLenghtErrorMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
