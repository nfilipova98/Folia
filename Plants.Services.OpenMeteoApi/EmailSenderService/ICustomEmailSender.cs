namespace Plants.Services.APIs.EmailSenderService
{
	public interface ICustomEmailSender
	{
		Task SendEmailAsync(string email, string subject, string htmlMessage);
		Task SendEmailAsync(string from, string to, string subject, string htmlContent);
	}
}
