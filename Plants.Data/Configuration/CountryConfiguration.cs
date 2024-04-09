namespace Plants.Data.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	
	using Models.ApplicationUser;

	public class CountryConfiguration : IEntityTypeConfiguration<Country>
	{
		private Country country = new Country
		{
			Id = 1,
			Name = "Bulgaria",
		};

		public void Configure(EntityTypeBuilder<Country> builder)
		{
			builder.HasData(country);
		}
	}
}
