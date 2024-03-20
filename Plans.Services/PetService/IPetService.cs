namespace Plants.Services.PetService
{
	using ViewModels;

	public interface IPetService
	{
		Task<IEnumerable<PetViewModel>> GetAllPetsAsync();
		Task CreateAsync(string name);
	}
}
