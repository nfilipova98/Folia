namespace Plants.Services.PlantService
{
	using Models;
	using ViewModels;

    using APIs.BlobService;

	public interface IPlantService : IBlobService
    {
		Task<bool> ExistsAsync(int id);
		Task<int> GetPlantsCount();
        Task<IEnumerable<PlantAllViewModel>> GetAllPlantsAsync<T>(int page, int itemsPerPage, string userId, string searchString);
		Task<IEnumerable<int>> GetPetIds(int id);
		Task CreatePlantAsync(string fileUrl, PlantEditOrAddViewModel model);
		Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync<T>(string id, int page, int itemsPerPage, string userId);
		Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants(string userId);
		Task EditAsync(int id, PlantEditOrAddViewModel model);
		Task<PlantEditOrAddViewModel> GetPlantAddOrEditModelAsync(int id);
		Task<PlantDeleteViewModel> DeleteAsync(int id);
		Task<bool> LikeButton(int id, bool isLiked, string userId);
	}
}
