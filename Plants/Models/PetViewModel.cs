namespace Plants.Models
{
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.PetConstants;

	using System.ComponentModel.DataAnnotations;

	public class PetViewModel
	{
		public int Id { get; set; }

		[StringLength(PetNameMaxLenght, MinimumLength = PetNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public string Name { get; set; } = string.Empty;
	}
}