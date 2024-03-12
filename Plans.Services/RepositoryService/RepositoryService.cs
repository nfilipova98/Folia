namespace Plants.Services.RepositoryService
{
    using Data;

    using Microsoft.EntityFrameworkCore;

    public class Repository : IRepository
    {
        private readonly PlantsDbContext _context;

        public Repository(PlantsDbContext context)
        {
            _context = context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

		public async Task<T?> FindByIdAsync<T>(int id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T?> FindByIdAsync<T>(string id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
