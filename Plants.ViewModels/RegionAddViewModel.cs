namespace Plants.ViewModels
{
	using static Services.Constants.GlobalConstants.CountryConstants;
	using static Services.Constants.GlobalConstants.ErrorMessages;
	using static Services.Constants.GlobalConstants.RegionConstants;

	using System.ComponentModel.DataAnnotations;

	public class RegionAddViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(RegionNameMaxLenght, MinimumLength = RegionNameMinLenght,
			ErrorMessage = StringLenghtErrorMessage)]
		[RegularExpression(@"\b[A-Z][a-z]*",
			ErrorMessage = CapitalLetter)]
		public string RegionName { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(CountryNameMaxLenght, MinimumLength = CountryNameMinLenght,
		ErrorMessage = StringLenghtErrorMessage)]
		public string CountryName { get; set; } = string.Empty;
	}
}
