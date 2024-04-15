namespace Plants.Data.Models.ApplicationUser
{
    using static Services.Constants.GlobalConstants.RegionConstants;

	using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Region
    {
		[Comment("Identifier")]
		public int Id { get; set; }

        [StringLength(RegionNameMaxLenght)]
		[Comment("Region name")]
		public required string Name { get; set; }

		[Required]
		[Comment("Country identifier")]
		public int CountryId { get; set; }
		public Country Country { get; set; } = null!;

        public ICollection<UserConfiguration> Users { get; set; } = new HashSet<UserConfiguration>();
    }
}
