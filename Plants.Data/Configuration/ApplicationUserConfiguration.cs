namespace Plants.Data.Configuration
{
	using Models.ApplicationUser;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
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