namespace Plants.ViewModels
{
    using static Services.Constants.GlobalConstants.ErrorMessages;
    using static Services.Constants.GlobalConstants.PetConstants;

    using System.ComponentModel.DataAnnotations;

    public class PetAddViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PetNameMaxLenght, MinimumLength = PetNameMinLenght,
            ErrorMessage = StringLenghtErrorMessage)]
        [RegularExpression(@"\b[A-Z][a-z]*",
            ErrorMessage = CapitalLetter)]
        public string Name { get; set; } = string.Empty;
    }
}
