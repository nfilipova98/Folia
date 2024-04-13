namespace Plants.Services.PetService
{
    using Plants.ViewModels;
    using ViewModels;

    public interface IPetService
	{
		Task<IEnumerable<PetViewModel>> GetAllPetsAsync();
		Task CreateAsync(string name);
	}
}
