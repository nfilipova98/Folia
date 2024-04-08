namespace Plants.Services.APIs.OpenMeteoService
{
    using static Constants.GlobalConstants.ApiConstants;

    using OpenMeteo;

    public class HumiditySetUp : IOpenMeteoService
	{
        public async Task<double?> GetHumidityAsync(string location, float? latitude, float? longitude)
        {
            OpenMeteoClient client = new();

            HourlyOptions hourlyOptions = new()
            {
                HourlyOptionsParameter.relativehumidity_2m,
            };

            WeatherForecastOptions weatherForecastOptions = new()
            {
                Hourly = hourlyOptions,
                Past_Days = PastDays
            };

            if (location == null)
            {
                weatherForecastOptions.Longitude = longitude.Value;
                weatherForecastOptions.Latitude = latitude.Value;
            }

            WeatherForecast weatherForecast = location == null
                ? await client.QueryAsync(weatherForecastOptions)
                : await client.QueryAsync(location, weatherForecastOptions);

            var result = weatherForecast.Hourly?.Relativehumidity_2m?.Average();

            return result;
        }
    }
}