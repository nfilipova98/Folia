namespace Plants.Services.OpenMeteoApi
{
    using static ApiConstants;

    using OpenMeteo;

    public class HumiditySetUp
    {
        static async Task<double?> GetHumidityAsync(string location, float latitude, float longitude)
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
                weatherForecastOptions.Longitude = longitude;
                weatherForecastOptions.Latitude = latitude;
            }

            WeatherForecast weatherForecast = location == null
                ? await client.QueryAsync(weatherForecastOptions)
                : await client.QueryAsync(location, weatherForecastOptions);

            var result = weatherForecast.Hourly?.Relativehumidity_2m?.Average();

            return result;
        }
    }
}