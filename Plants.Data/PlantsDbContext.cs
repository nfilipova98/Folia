namespace Plants.Data
{
    using Configuration;
    using Models.ApplicationUser;
    using Models.Comment;
    using Models.Pet;
    using Models.Plant;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class PlantsDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlantsDbContext(DbContextOptions<PlantsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<UserConfiguration> UserConfigurations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration(use));
            modelBuilder.ApplyConfiguration(new PlantConfiguration());
            modelBuilder.ApplyConfiguration(new PetConfiguration());
        }
    }
}
