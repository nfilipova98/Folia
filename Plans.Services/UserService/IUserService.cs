namespace Plants.Services.UserService
{
	using ViewModels;

	public interface IUserService
	{
		Task<FirstLoginViewModel> GetModels();
	}
}
