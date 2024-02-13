namespace Plants.Services.AdminService
{
    using Models;
    using Plants.Services.Data.AdminService.Models;

    public interface IAdminService
    {
        Task AddPlantAsync(PlantModel model);
        Task DeletePlantAsync(int id);
		Task EditPlantAsync(PlantModel model);
        Task<PlantModel?> GetPlantByIdAsync(int id);
        Task<IEnumerable<PlantModel>> GetAllPlantsAsync();

		Task AddApplicationUserAsync(ApplicationUserModel model);
		Task DeleteApplicationUserAsync(int id);
		Task EditApplicationUserAsync(ApplicationUserModel model);
		Task<ApplicationUserModel?> GetApplicationUserByIdAsync(int id);
		Task<IEnumerable<ApplicationUserModel>> GetAllApplicationUsersAsync();

		Task AddCommentAsync(CommentModel model);
		Task DeleteCommentAsync(int id);
		Task EditCommentAsync(CommentModel model);

	}
}
