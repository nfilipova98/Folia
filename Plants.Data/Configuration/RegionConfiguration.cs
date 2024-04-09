namespace Plants.Data.Configuration
{
	using Models.ApplicationUser;
	
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class RegionConfiguration : IEntityTypeConfiguration<Region>
	{
		private readonly IEnumerable<Region> initialRegions = new Region[]
		{
			new Region
			{
				Id = 1,
				Name = "Varna",
				CountryId = 1,
			},
			new Region
			{
				Id = 2,
				Name = "Sofia",
				CountryId = 1,
			},
			new Region
			{
				Id = 3,
				Name = "Plovdiv",
				CountryId = 1,
			},
			new Region
			{
				Id = 4,
				Name = "Veliko Tarnovo",
				CountryId = 1,
			},
			new Region
			{
				Id = 5,
				Name = "Silistra",
				CountryId = 1,
			},
			new Region
			{
				Id = 6,
				Name = "Burgas",
				CountryId = 1,
			},
			new Region
			{
				Id = 7,
				Name = "Gabrovo",
				CountryId = 1,
			},
			new Region
			{
				Id = 8,
				Name = "Sliven",
				CountryId = 1,
			},
			new Region
			{
				Id = 9,
				Name = "Haskovo",
				CountryId = 1,
			},
			new Region
			{
				Id = 10,
				Name = "Pleven",
				CountryId = 1,
			},
			new Region
			{
				Id = 11,
				Name = "Vidin",
				CountryId = 1,
			},
			new Region
			{
				Id = 12,
				Name = "Vratsa",
				CountryId = 1,
			},
			new Region
			{
				Id = 13,
				Name = "Kyustendil",
				CountryId = 1,
			},
			new Region
			{
				Id = 14,
				Name = "Targovishte",
				CountryId = 1,
			},
			new Region
			{
				Id = 15,
				Name = "Dobrich",
				CountryId = 1,
			},
			new Region
			{
				Id = 16,
				Name = "Razgrad",
				CountryId = 1,
			},
			new Region
			{
				Id = 17,
				Name = "Montana",
				CountryId = 1,
			},
			new Region
			{
				Id = 18,
				Name = "Lovech",
				CountryId = 1,
			},
			new Region
			{
				Id = 19,
				Name = "Ruse",
				CountryId = 1,
			},
			new Region
			{
				Id = 20,
				Name = "Shumen",
				CountryId = 1,
			},
			new Region
			{
				Id = 21,
				Name = "Yambol",
				CountryId = 1,
			},
			new Region
			{
				Id = 22,
				Name = "Smolyan",
				CountryId = 1,
			},
			new Region
			{
				Id = 23,
				Name = "Kurdzhali",
				CountryId = 1,
			},
			new Region
			{
				Id = 24,
				Name = "Pazardzhik",
				CountryId = 1,
			},
			new Region
			{
				Id = 25,
				Name = "Blagoevgrad",
				CountryId = 1,
			},
			new Region
			{
				Id = 26,
				Name = "Montana",
				CountryId = 1,
			},

		};

		public void Configure(EntityTypeBuilder<Region> builder)
		{
			builder.HasData(initialRegions);
		}
	}
}
