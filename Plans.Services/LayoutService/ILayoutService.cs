namespace Plants.Services.LayoutService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;

	public interface ILayoutService
	{
		Task<Tier?> FindUsersTierByIdAsync(string userId);
		Task<string?> FindUsersPictureByIdAsync(string userId);
		Task<UserConfiguration?> GetUserConfiguration(string userId);
	}
}
