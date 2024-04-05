namespace Plants.Services.APIs.EmailSenderService
{
	using static Constants.GlobalConstants.AdminConstants;

	using Microsoft.Extensions.Logging;
	using Microsoft.Extensions.Options;
	using Models;
	using SendGrid;
	using SendGrid.Helpers.Mail;

	public class EmailSender : ICustomEmailSender
	{
		private readonly ILogger _logger;

		public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
						   ILogger<EmailSender> logger)
		{
			Options = optionsAccessor.Value;
			_logger = logger;
		}

		public AuthMessageSenderOptions Options { get; }

		public async Task SendEmailAsync(string toEmail, string subject, string message)
		{
			if (string.IsNullOrEmpty(Options.SendGridKey))
			{
				throw new Exception("Null SendGridKey");
			}

			await Execute(Options.SendGridKey, subject, message, toEmail);
		}

		public async Task SendEmailAsync(string from, string to, string subject, string textMessage)
		{
			var client = new SendGridClient(Options.SendGridKey);

			var toAddress = new EmailAddress(to);
			var fromAddress = new EmailAddress(from);

			var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, textMessage, null);

			var response = await client.SendEmailAsync(message);
			_logger.LogInformation(response.IsSuccessStatusCode
								  ? $"Email to {from} queued successfully!"
								  : $"Failure Email to {from}");
		}

		private async Task Execute(string apiKey, string subject, string message, string toEmail)
		{
			var client = new SendGridClient(apiKey);

			var msg = new SendGridMessage()
			{
				From = new EmailAddress(AdminMail, "Plants Team 🌱"),
				Subject = subject,
				PlainTextContent = message,
				HtmlContent = message,
			};

			msg.AddTo(new EmailAddress(toEmail));

			msg.SetClickTracking(false, false);
			var response = await client.SendEmailAsync(msg);
			_logger.LogInformation(response.IsSuccessStatusCode
								  ? $"Email to {toEmail} queued successfully!"
								  : $"Failure Email to {toEmail}");
		}
	}
}
