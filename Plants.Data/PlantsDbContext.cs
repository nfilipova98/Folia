namespace Plants.Data
{
    using Models.User;
    using Models.Plant;
    using Models.Pet;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class PlantsDbContext : IdentityDbContext
    {
        public PlantsDbContext(DbContextOptions<PlantsDbContext> options) 
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserConfiguration> UsersConfigurations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantInfo> PlantsInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
