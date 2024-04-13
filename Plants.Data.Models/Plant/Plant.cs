namespace Plants.Data.Models.Plant
{
    using ApplicationUser;
    using Comment;
    using Enums;
    using Pet;
	using static Services.Constants.GlobalConstants.PlantConstants;

	using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Plant
    {
		[Comment("Identifier")]
		public int Id { get; set; }

        [StringLength(PlantNameMaxLenght)]
		[Comment("Plant common name")]
		public required string Name { get; set; }

        [StringLength(PlantScientificNameMaxLenght)]
		[Comment("Plant scientific name")]
		public string? ScientificName { get; set; }

		[Comment("Plant image")]
		public required string ImageUrl { get; set; }

        public required Humidity Humidity { get; set; }

        public required Difficulty Difficulty { get; set; }

        /// <summary>
        /// Depends on how frequently you have to water it
        /// </summary>
        public required Lifestyle Lifestyle { get; set; }

        public required bool KidSafe { get; set; }

        public required bool IsTrending { get; set; } = false;

        public required string Description { get; set; } = string.Empty;

        public ICollection<ApplicationUser> UsersLikedPlant { get; set; } = new HashSet<ApplicationUser>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        /// <summary>
        /// List of pets that may have bad reactions from the plant
        /// </summary>
        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}
