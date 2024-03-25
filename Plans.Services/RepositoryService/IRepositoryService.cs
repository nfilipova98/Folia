namespace Plants.Services.RepositoryService
{
	public interface IRepositoryService
	{
		IQueryable<T> All<T>() where T : class;
		IQueryable<T> AllReadOnly<T>() where T : class;
		Task AddAsync<T>(T entity) where T : class;
		Task<T?> FindByIdAsync<T>(int id) where T : class;
		Task<T?> FindByIdAsync<T>(string id) where T : class;
		Task<int> SaveChangesAsync();
		void UpdateAsync<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
	}
}