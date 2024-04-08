namespace Plants.Services.APIs.OpenMeteoService
{
	public interface IOpenMeteoService
	{
		Task<double?> GetHumidityAsync(string location, float? latitude, float? longitude);
	}
}
