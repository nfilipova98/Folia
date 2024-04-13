namespace Plants.Data.Models.Enums
{
	using Microsoft.OpenApi.Attributes;

	public enum Humidity
	{
		/// <summary>
		/// Low - 0-25 %
		/// Moderate - 26-50 %
		/// High - 51-75 %
		/// Very High - 76-100 %
		/// </summary>

		Low = 0,
		Moderate = 1,
		High = 2,
		[Display("Very High")]
		VeryHigh = 3,
	}
}
