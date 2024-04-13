namespace Plants.Data.Models.ApplicationUser
{
	using static Services.Constants.GlobalConstants.CountryConstants;

	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;

	public class Country
	{
		[Comment("Identifier")]
		public int Id { get; set; }

		[StringLength(CountryNameMaxLenght)]
		[Comment("Country name")]
		public required string Name { get; set; }

		public ICollection<Region> Regions { get; set; } = new HashSet<Region>();
	}
}
