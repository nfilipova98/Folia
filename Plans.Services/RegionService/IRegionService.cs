namespace Plants.Services.RegionService
{
	using Data.Models.ApplicationUser;
	using ViewModels;

	public interface IRegionService
	{
		Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync();
		Task<IEnumerable<Region>> GetHumidityAsync(IEnumerable<Region> regions);
	}
}
