namespace Plants.ViewModels
{
	using static Services.Constants.GlobalConstants.ErrorMessages;

	using System.ComponentModel.DataAnnotations;

	public class ContactViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string Subject { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Message { get; set; } = string.Empty;
	}
}
