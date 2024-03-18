namespace Plants.Data.Seeding
{
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(PlantsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
                new UserSeeder()
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
