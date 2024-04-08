namespace Plants.Services.RegionService
{
	using ViewModels;

	public interface IRegionService
	{
		Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync();
		//Task CreateAsync(string cityName, string countryName);
	}
}
