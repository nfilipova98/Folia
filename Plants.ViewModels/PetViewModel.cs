namespace Plants.Models
{
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.PetConstants;

	using System.ComponentModel.DataAnnotations;

	public class PetViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(PetNameMaxLenght, MinimumLength = PetNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public string Name { get; set; } = string.Empty;
	}
}