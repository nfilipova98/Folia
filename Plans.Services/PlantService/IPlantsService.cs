namespace Plants.Services.PlantService
{
	using Models;

	public interface IPlantService
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
		Task<string> UploadFileAsync(ImageModel file);
		Task DeleteFileAsync(string url, int plantId);
	}
}
