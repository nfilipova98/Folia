namespace Plants.Data.Configuration
{
    using Models.Pet;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        private IEnumerable<Pet> initialPets = new Pet[]
        {
            new Pet
            {
                Id = 1,
                Name = "Cat",
            },
            new Pet
            {
                Id = 2,
                Name = "Dog",
            },
        };

        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(initialPets);
        }
    }
}
