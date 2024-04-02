namespace Plants.Services.UserService
{
	using Plants.Data.Models.Enums;
	using ViewModels;

	public interface IUserService
	{
		Task<FirstLoginViewModel> GetModels();
		Task<Tier?> FindUserByIdAsync(string userId);
	}
}
