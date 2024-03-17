namespace Plants.Services.PetService
{
	using Models;

	public interface IPetService
	{
		Task<IEnumerable<PetViewModel>> GetAllPetsAsync();
	}
}
