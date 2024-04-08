namespace Plants.ViewModels
{
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.CityConstants;
	using static Services.Constants.GlobalConstants.CountryConstants;

	using System.ComponentModel.DataAnnotations;

	public class CityAddViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(CityNameMaxLenght, MinimumLength = CityNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		[RegularExpression(@"\b[A-Z][a-z]*",
			ErrorMessage = CapitalLetter)]
		public string CityName { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(CountryNameMaxLenght, MinimumLength = CountryNameMinLenght,
		ErrorMessage = StringLenghtErrorMessage)]
		public string CountryName { get; set; } = string.Empty;
	}
}
