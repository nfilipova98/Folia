namespace Plants.Controllers
{
    using Services.ContactsService;
    using ViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
	{
		private readonly IContactsService _contactsService;
		private readonly ILogger _logger;

		public ContactsController(IContactsService contactsService, ILogger<ContactsController> logger)
		{
			_contactsService = contactsService;
			_logger = logger;
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
				_logger.LogError("ContactsController/SendMessage - ModelState was not valid");
				return View(model);
			}

			try
			{
				await _contactsService.SendEmail(model);
			}
			catch (Exception)
			{
				throw;
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
