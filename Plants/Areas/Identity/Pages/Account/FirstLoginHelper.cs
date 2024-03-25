namespace Plants.Areas.Identity.Pages.Account
{
	using Data.Models.ApplicationUser;
	using Services.RepositoryService;

	using Microsoft.AspNetCore.Mvc;

	public class FirstLoginHelper
	{
		private readonly IRepositoryService _repository;

		public FirstLoginHelper(IRepositoryService repository)
		{
			_repository = repository;
		}

		public async Task<bool> FirstTimeLogin(string userId)
		{
			var getUser = await _repository.FindByIdAsync<ApplicationUser>(userId);

			if (getUser != null)
			{
				var userConfiguration = getUser.UserConfigurationIsNull;
				var isFirstTimeLogin = getUser.IsFirstTimeLogin;

				if (userConfiguration && isFirstTimeLogin)
				{
					getUser.IsFirstTimeLogin = false;
					getUser.UserConfigurationIsNull = false;

					await _repository.SaveChangesAsync();

					return true;
				}
			}

			return false;
		}
	}
}
