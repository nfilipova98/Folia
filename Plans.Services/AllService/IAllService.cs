namespace Plants.Services.AllService
{
	public interface IAllService
	{
		Task<IEnumerable<T>> GetAllAsync<T>();
	}
}
