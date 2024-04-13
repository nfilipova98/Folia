namespace Plants.Services.RegionService
{
    using Plants.ViewModels;
    using ViewModels;

    public interface IRegionService
	{
		Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync();
		Task<double?> GetHumidityAsync(string region);
	}
}
