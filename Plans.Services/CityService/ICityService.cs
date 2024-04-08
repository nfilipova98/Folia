namespace Plants.Services.CityService
{
	using ViewModels;

	public interface ICityService
	{
		Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();
		Task CreateAsync(string cityName, string countryName);
	}
}
