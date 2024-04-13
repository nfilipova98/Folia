namespace Plants.Services.UserService
{
    using ViewModels;

    public interface IUserService
	{
		Task AddUserInformation(ProfileViewModel model, string url, string userId);
		Task<string> UploadFileAsync(ImageModel file);
		Task DeleteFileAsync(string url, string userId);
		Task<ProfileViewModel> GetModels(string? userId);
	}
}
