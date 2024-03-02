namespace Plants.Data.Configuration
{
	using Models.ApplicationUser;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		//private async Task<ApplicationUser> CreateAdminProfileAsync()
		//{
		//	var adminUserId = Guid.NewGuid().ToString();

		//	var adminRole = new IdentityRole
		//	{
		//		Name = "Admin",
		//		NormalizedName = "ADMIN"
		//	};

		//	await _roleManager.CreateAsync(adminRole);

		//	var existingAdmin = await _userManager.FindByEmailAsync("nfilipova@students.softuni.bg");

		//	var adminUser = new ApplicationUser
		//	{
		//		Id = adminUserId,
		//		UserName = "nfilipova@students.softuni.bg",
		//		NormalizedUserName = "nfilipova@students.softuni.bg".ToUpper(),
		//		EmailConfirmed = true,
		//		Tier = Models.Enums.Tier.Blossom,
		//		UserConfigurationIsNull = true
		//	};

		//	var result = await _userManager.CreateAsync(adminUser, "X9U6h1GPq4WzZfloaKRwPD");

		//	if (result.Succeeded)
		//	{
		//		await _userManager.AddToRoleAsync(adminUser, "Admin");
		//		return adminUser;
		//	}
		//	else
		//	{
		//		var errors = string.Join(", ", result.Errors.Select(e => e.Description));
		//		throw new ApplicationException($"Error creating admin user: {errors}");
		//	}

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
		}
	}
}