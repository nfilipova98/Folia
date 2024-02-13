namespace Plants.Data.Configuration
{
	using Models.ApplicationUser;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.AspNetCore.Identity;

	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		private UserManager<ApplicationUser> _userManager;

		public ApplicationUserConfiguration(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		private async Task<ApplicationUser> CreateAdminProfileAsync()
		{
			var admin = new ApplicationUser()
			{
				UserName = "nfilipova@students.softuni.bg",
				NormalizedUserName = "nfilipova@students.softuni.bg".ToUpper(),
				Tier = Models.Enums.Tier.Blossom,
				UserConfigurationIsNull = true
			};

			var password = _userManager.PasswordHasher.HashPassword(admin, "X9U6h1GPq4WzZfloaKRwPD");

			await _userManager.CreateAsync(admin, password);

			return admin;
		}

		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder
				.HasMany(x => x.LikedPlants)
				.WithMany(x => x.UsersLikedPlant)
				.UsingEntity(x => x.ToTable("ApplicationUsersLikedPlants"));

			builder
				.HasMany(x => x.PlantsOwned)
				.WithMany(x => x.Owners)
				.UsingEntity(x => x.ToTable("ApplicationUsersOwnedPlants"));

			builder
				.ToTable("ApplicationUsers")
				.HasOne(x => x.UserConfiguration)
				.WithOne(x => x.ApplicationUser)
				.HasForeignKey<UserConfiguration>(x => x.ApplicationUserId);

			builder
				.HasData(CreateAdminProfileAsync());
		}
	}
}
