namespace Plants.Services.ContactsService
{
    using ViewModels;

    public interface IContactsService
	{
		Task SendEmail(ContactViewModel model);
	}
}
