namespace Plants.Services.PlantService
{
	using Models;

    using APIs.BlobService;

	public interface IPlantService : IBlobService
    {
		Task<IEnumerable<PlantHomeViewModel>> GetAllPlantsAsync();
		Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync();
		Task<PlantDeleteViewModel> DeleteAsync(int id);
	}
}
