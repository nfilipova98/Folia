namespace Plants.Services.APIs.OpenMeteoService
{
	using Data.Models.Enums;

	public interface IOpenMeteoService
	{
		Task<Humidity?> GetHumidityAsync(string location);
	}
}
