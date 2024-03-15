namespace Plants.Services.Pet
{
	using Models;

	public interface IPetService
	{
		Task<IEnumerable<PetViewModel>> GetPetsAsync();
	}
}
