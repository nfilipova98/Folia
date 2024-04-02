namespace Plants.Controllers
{
	using Services.ContactsService;
	using ViewModels;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class ContactsController : BaseController
	{
		private readonly IContactsService _contactsService;

		public ContactsController(IContactsService contactsService)
		{
			_contactsService = contactsService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = new ContactViewModel();

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> SendMessage(ContactViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _contactsService.SendEmail(model);

			return RedirectToAction(nameof(Index));
		}
	}
}
