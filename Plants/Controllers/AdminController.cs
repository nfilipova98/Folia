//namespace Plants.Controllers
//{
//	using Data.Models.ApplicationUser;

//	using Microsoft.AspNet.Identity;
//	using Microsoft.AspNetCore.Authorization;
//	using Microsoft.AspNetCore.Mvc;
//	using Microsoft.Extensions.DependencyInjection;

//	public class AdminController : BaseController
//	{
//		private readonly IServiceProvider _serviceProvider;

//		public AdminController(IServiceProvider serviceProvider)
//		{
//			_serviceProvider = serviceProvider;
//		}

//		[AllowAnonymous]
//		public IActionResult Index()
//		{
//			return View();
//		}

//		[HttpPost]
//		public async Task<IActionResult> AssignUserToRole(string userId, string roleName)
//		{
//			var manager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//			var roleresult = await manager.AddToRoleAsync(userId, "roleName");

//			if (result.Succeeded)
//			{

//				await SignInAsync(user, isPersistent: false);
//			}
//			foreach (string error in result.Errors)
//			{
//				ModelState.AddModelError("", error);
//			}

//			return View();
//		}
//	}
//}
