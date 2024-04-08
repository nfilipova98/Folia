namespace Plants.Services.UserService
{
	using Data.Models.Enums;
	using Models;
	using ViewModels;

	public interface IUserService
	{
		Task<FirstLoginViewModel> GetModels();
		Task AddUserInformation(FirstLoginViewModel model, string url, string userId);
		Task<Tier?> FindUserByIdAsync(string userId);
		Task<string> UploadFileAsync(ImageModel file);
		Task DeleteFileAsync(string url, string userId);
	}
}
