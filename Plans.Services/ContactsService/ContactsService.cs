namespace Plants.Services.ContactsService
{
	using APIs.EmailSenderService;
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
			await _emailSender.SendEmailAsync(model.Email, "nfilipova@students.softuni.bg", model.Subject, model.Message);
		}
	}
}
