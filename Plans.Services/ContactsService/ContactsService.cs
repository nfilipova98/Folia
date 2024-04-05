namespace Plants.Services.ContactsService
{
	using APIs.EmailSenderService;
	using static Constants.GlobalConstants.AdminConstants;
	using ViewModels;

	public class ContactsService : IContactsService
	{
		private readonly ICustomEmailSender _emailSender;

		public ContactsService(ICustomEmailSender emailSender)
		{
			_emailSender = emailSender;
		}

		public async Task SendEmail(ContactViewModel model)
		{
			await _emailSender.SendEmailAsync(model.Email, AdminMail, model.Subject, model.Message);
		}
	}
}
