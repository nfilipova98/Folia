namespace Plants.Data.Models.Enums
{
	using Microsoft.OpenApi.Attributes;

	public enum Lifestyle
	{
		/// <summary>
		/// Depending on the Lifestyle of the person, a plant that is low or high maintnance is recommended.
		/// For example if you are a Traveller a low maintnance plant is recommended.
		/// </summary>

		//SemiActive
		//OnTheGo

		Homebody = 0,
		[Display("Semi-Active")]
		SemiActive = 1,
		[Display("On-The-Go")]
		OnTheGo = 2
	}
}
