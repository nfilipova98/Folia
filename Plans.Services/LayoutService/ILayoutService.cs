namespace Plants.Services.LayoutService
{
	using Plants.Data.Models.Enums;

	public interface ILayoutService
	{
		Task<Tier?> FindUsersTierByIdAsync(string userId);
		Task<string?> FindUsersPictureByIdAsync(string userId);
	}
}
