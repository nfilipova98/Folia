namespace Plants.ViewModels
{
	using static Services.Constants.GlobalConstants.ErrorMessages;

	using System.ComponentModel.DataAnnotations;

	public class ContactViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Email { get; set; } = string.Empty;

		public string? Subject { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public string Message { get; set; } = string.Empty;
	}
}
