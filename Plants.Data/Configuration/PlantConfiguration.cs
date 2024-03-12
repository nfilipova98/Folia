namespace Plants.Data.Configuration
{
	using Models.Enums;
	using Models.Plant;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class PlantConfiguration : IEntityTypeConfiguration<Plant>
	{
		private IEnumerable<Plant> initialPlants = new Plant[]
		{
			new Plant
			{
				Id = 1,
				Name = "Buddhist Pine",
				ScientificName = "Podocarpus Macrophyllus",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.Moderate,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/0.jpg",
			},
			new Plant
			{
				Id = 2,
				Name = "Spider plant",
				ScientificName = "Chlorophytum comosum",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.Moderate,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = false,
				IsTrending = false,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/13.jpg"
			},
			new Plant
			{
				Id = 3,
				Name = "Rubber fig",
				ScientificName = "Ficus elastica",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.High,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = false,
				IsTrending = false,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/10.jpg"
			},
			new Plant
			{
				Id = 4,
				Name = "Areca palm",
				ScientificName = "Dypsis lutescens",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.Moderate,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = false,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/12.jpg"
			},
			new Plant
			{
				Id = 5,
				Name = "Watermelon Peperomia",
				ScientificName = "Peperomia argyreia",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.High,
				KidSafe = true,
				Lifestyle = Lifestyle.InBetween,
				Outdoor = false,
				IsTrending = false,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/11.jpg"
			},
			new Plant
			{
				Id = 6,
				Name = "Snake Plant",
				ScientificName = "Dracaena Trifasciata",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.High,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = false,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/1.jpg",
			},
			new Plant
			{
				Id = 7,
				Name = "Swiss cheese plant",
				ScientificName = "Monstera minima",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.High,
				KidSafe = false,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/8.jpg"
			},
			new Plant
			{
				Id = 8,
				Name = "Cherry Laurel Novita",
				ScientificName = "Prunus Laurocerasus Novita",
				Difficulty = Difficulty.Medium,
				Humidity = Humidity.Moderate,
				KidSafe = false,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/2.jpg",
			},
			new Plant
			{
				Id = 9,
				Name = "Vanuatu Fan Palm",
				ScientificName = "Licuala grandis",
				Difficulty = Difficulty.Medium,
				Humidity = Humidity.High,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/3.jpg",
			},
			new Plant
			{
				Id = 10,
				Name = "Peruvian apple cactus",
				ScientificName = "Cereus Peruvianus",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.Low,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/4.jpg",
			},
			new Plant
			{
				Id = 11,
				Name = "Boston Fern",
				ScientificName = "Nephrolepis exaltata",
				Difficulty = Difficulty.Medium,
				Humidity = Humidity.High,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/5.jpg",
			},
			new Plant
			{
				Id = 12,
				Name = "Kentia Palm",
				ScientificName = "Howea forsteriana",
				Difficulty = Difficulty.Medium,
				Humidity = Humidity.High,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/6.jpg",
			},
			new Plant
			{
				Id = 13,
				Name = "ZZ Plant",
				ScientificName = "Zamioculcas",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.Moderate,
				KidSafe = true,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = true,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/7.jpg",
			},
			new Plant
			{
				Id = 14,
				Name = "Heart of Jesus",
				ScientificName = "Caladium Bicolour",
				Difficulty = Difficulty.Medium,
				Humidity = Humidity.High,
				KidSafe = false,
				Lifestyle = Lifestyle.Traveller,
				Outdoor = false,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/9.jpg",
			},
		};

		public void Configure(EntityTypeBuilder<Plant> builder)
		{
			builder.HasData(initialPlants);
		}
	}
}
