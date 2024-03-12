namespace Plants.Services.RepositoryService
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllReadOnly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<T?> FindByIdAsync<T>(int id) where T : class;
        Task<T?> FindByIdAsync<T>(string id) where T : class;
        Task<int> SaveChangesAsync();
    }
}