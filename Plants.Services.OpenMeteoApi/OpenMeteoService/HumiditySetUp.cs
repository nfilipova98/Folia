namespace Plants.Services.APIs.OpenMeteoService
{
	using Data.Models.Enums;
    using static Constants.GlobalConstants.ApiConstants;

    using OpenMeteo;

	public class HumiditySetUp : IOpenMeteoService
	{
        public async Task<Humidity?> GetHumidityAsync(string location)
        {
            var result = Humidity.Low;

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

            WeatherForecast weatherForecast = await client.QueryAsync(location, weatherForecastOptions);

            var percentage = weatherForecast.Hourly?.Relativehumidity_2m?.Average();

            if (percentage == null)
            {
                //throw 
            }
			else if (percentage >= 0 && percentage <= 25)
            {
				result = Humidity.Low;
			}
			else if (percentage > 25 && percentage <= 50)
			{
				result = Humidity.Moderate;
			}
			else if (percentage > 50 && percentage <= 75)
			{
				result = Humidity.High;
			}
			else if (percentage > 75 && percentage <= 100)
			{
				result = Humidity.VeryHigh;
			}

			return result;
        }
    }
}