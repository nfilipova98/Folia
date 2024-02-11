namespace Plants.Data
{
    using Models.User;
    using Models.Plant;
    using Models.Pet;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class PlantsDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlantsDbContext(DbContextOptions<PlantsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<UserConfiguration> UsersConfigurations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantInfo> PlantsInfo { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.LikedPlants)
                .WithMany(x => x.UsersLikedPlant)
                .UsingEntity(x => x.ToTable("ApplicationUsersLikedPlants"));

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.PlantsOwned)
                .WithMany(x => x.Owners)
                .UsingEntity(x => x.ToTable("ApplicationUsersOwnedPlants"));

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("ApplicationUser")
                .HasOne(x => x.UserConfiguration)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey<UserConfiguration>(x => x.ApplicationUserId);
        }
    }
}
