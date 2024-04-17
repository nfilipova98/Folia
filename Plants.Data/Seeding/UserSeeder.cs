namespace Plants.Data.Seeding
{
	using Models.ApplicationUser;
	using Models.Enums;
	using static Services.Constants.GlobalConstants.AdminConstants;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;

	public class UserSeeder : ISeeder
	{
		public async Task SeedAsync(PlantsDbContext dbContext, IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			await SeedAdminAsync(userManager, "nfilipova98@gmail.com");
			await SeedUserAsync(userManager, "1@gmail.com");
		}

		private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, string email)
		{
			var user = await userManager.FindByEmailAsync(email);

			if (user == null)
			{
				user = new ApplicationUser
				{
					UserName = email,
					Email = email,
					Tier = Tier.Blossom,
					IsFirstTimeLogin = false,
					UserConfigurationIsNull = true,
					TierPoints = 100,
					EmailConfirmed = true
				};

				var passwordHasher = new PasswordHasher<ApplicationUser>();
				var password = "r$Sr#&rZn#eHAzS4";

				var result = await userManager.CreateAsync(user, password);

				if (!result.Succeeded)
				{
					throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
				}

				await userManager.AddToRoleAsync(user, Admin);
			}
		}

		private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string email)
		{
			var user = await userManager.FindByEmailAsync(email);

			if (user == null)
			{
				user = new ApplicationUser
				{
					UserName = email,
					Email = email,
					Tier = Tier.Seed,
					IsFirstTimeLogin = true,
					UserConfigurationIsNull = false,
					TierPoints = 0,
					EmailConfirmed = true
				};

				var passwordHasher = new PasswordHasher<ApplicationUser>();

				var password = "Aa123456.";
				var result = await userManager.CreateAsync(user, password);

				if (!result.Succeeded)
				{
					throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
				}

				await userManager.AddToRoleAsync(user, "User");
			}
		}
	}
}
