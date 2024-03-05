namespace Plants.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(PlantsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
