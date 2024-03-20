namespace Plants.Services.PlantService
{
	using Models;

    using APIs.BlobService;

	public interface IPlantService : IBlobService
    {
		Task<bool> ExistsAsync(int id);
		Task<int> GetPlantsCount();
		Task<IEnumerable<T>> GetAllPlantsAsync<T>(int page, int itemsPerPage);
		Task<IEnumerable<int>> GetPetIds(int id);
		Task CreatePlantAsync(string fileUrl, PlantEditOrAddViewModel model);
		Task<IEnumerable<T>> GetFavoritePlantsAsync<T>(string id, int page, int itemsPerPage);
		Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants();
		Task EditAsync(int id, PlantEditOrAddViewModel model);
		Task<PlantEditOrAddViewModel> GetPlantAddOrEditModelAsync(int id);
		Task<PlantDeleteViewModel> DeleteAsync(int id);
	}
}
