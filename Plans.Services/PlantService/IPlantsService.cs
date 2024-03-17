namespace Plants.Services.PlantService
{
	using Models;

    using APIs.BlobService;

	public interface IPlantService : IBlobService
    {
		Task<bool> ExistsAsync(int id);
		Task<IEnumerable<PlantAllViewModel>> GetAllPlantsAsync();
		Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync(string id);
		Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants();
		Task EditAsync(int id, PlantEditOrAddViewModel model);
		Task<PlantEditOrAddViewModel> GetPlantAddOrEditModelAsync(int id);
		Task<PlantDeleteViewModel> DeleteAsync(int id);
	}
}
