namespace Plants.ViewModels
{
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.CityConstants;

	using System.ComponentModel.DataAnnotations;

	public class CityViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(CityNameMaxLenght, MinimumLength = CityNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		public string Name { get; set; } = string.Empty;
	}
}
