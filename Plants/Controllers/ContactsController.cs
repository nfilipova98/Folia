namespace Plants.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class ContactsController : BaseController
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
	}
}
