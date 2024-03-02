namespace Plants.Data.Configuration
{
	using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(PlantsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
