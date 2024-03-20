namespace Plants.Services.ContactsService
{
	using APIs.EmailSenderService;
	using ViewModels;

	public class ContactsService : IContactsService
	{
		private readonly EmailSender _emailSender;

		public ContactsService(EmailSender emailSender)
		{
			_emailSender = emailSender;
		}

		public async Task SendEmail(ContactViewModel model)
		{
			var message = model.Message;

			var result = _emailSender.SendEmailAsync("nfilipova98@gmail.com", "ContactsRequest", message);
		}
	}
}
