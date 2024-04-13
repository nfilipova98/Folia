namespace Plants.Services.ContactsService
{
    using Plants.ViewModels;
    using ViewModels;

    public interface IContactsService
	{
		Task SendEmail(ContactViewModel model);
	}
}
