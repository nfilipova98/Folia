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
                Name = "Swiss cheese plant",
                ScientificName = "Monstera",
                Difficulty = Difficulty.Easy,
                Humidity = Humidity.High,
                KidSafe = false,
                Lifestyle = Lifestyle.Traveller,
                Outdoor = true,
                IsTrending = false,
                ImageUrl = ""
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
                ImageUrl = ""
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
                ImageUrl = ""
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
                ImageUrl = ""
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
                ImageUrl = ""
            }
        };

        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasData(initialPlants);
        }
    }
}
