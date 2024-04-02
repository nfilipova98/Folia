namespace Plants.Services.PlantService
{
	using Models;

    using APIs.BlobService;

	public interface IPlantService : IBlobService
    {
		Task<bool> ExistsAsync(int id);
        Task<IEnumerable<PlantAllViewModel>> GetAllPlantsAsync(string userId, string searchString);
		Task<IEnumerable<int>> GetPetIds(int id);
		Task<IEnumerable<T>> Pagination<T>(IEnumerable<T> model, int page);
		Task CreatePlantAsync(string fileUrl, PlantEditOrAddViewModel model);
		Task<IEnumerable<PlantAllViewModel>> GetFavoritePlantsAsync(string userId);
		Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants(string userId);
		Task EditAsync(int id, PlantEditOrAddViewModel model);
		Task<PlantEditOrAddViewModel> GetPlantAddOrEditModelAsync(int id);
		Task<PlantDeleteViewModel> DeleteAsync(int id);
		Task LikeButton(int id, bool isLiked, string userId);
	}
}
