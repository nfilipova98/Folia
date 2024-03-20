namespace Plants.Utilities
{
	using Data.Models.ApplicationUser;
	using Services.RepositoryService;

	using Microsoft.AspNetCore.Mvc.Filters;
	using System.Security.Claims;
	using Microsoft.AspNetCore.Mvc;
	using System.Threading.Tasks;

	public class ProfileSetUpFilter : ResultFilterAttribute
	{
		private IRepository _repository;

		public ProfileSetUpFilter(IRepository repository)
		{
			_repository = repository;
		}

		public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			var user = context.HttpContext.User;
			var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
			var getUser = await _repository.FindByIdAsync<ApplicationUser>(userId);

			bool toContinue = true;

			if (user.IsInRole("Admin") || !user.Identity.IsAuthenticated || userId == null)
			{
				toContinue = false;
			}

			await next();

			if (toContinue)
			{
				var userConfiguration = getUser?.UserConfigurationIsNull;
				var firsTimeLogIn = getUser?.IsFirstTimeLogin;

				if (userConfiguration == false && firsTimeLogIn == false)
				{
					context.Result = new ViewResult
					{
						ViewName = "FirstLoginView.cshtml"
					};
				}
			}
		}

	}
}
