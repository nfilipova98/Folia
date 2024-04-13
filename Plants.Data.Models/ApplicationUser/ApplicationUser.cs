namespace Plants.Data.Models.ApplicationUser
{
    using Comment;
    using Enums;
    using Plant;

    using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationUser : IdentityUser
    {
		[Comment("Profile tier")]
		public required Tier Tier { get; set; }

		[Comment("Profile tier points")]
		public required int TierPoints { get; set; }

        [Comment("Additional profile configuration")]
        public int? UsersConfigurationId { get; set; }
        public UserConfiguration? UserConfiguration { get; set; }

		public required bool UserConfigurationIsNull { get; set; } = true;

		public required bool IsFirstTimeLogin { get; set; } = true;

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Plant> LikedPlants { get; set; } = new HashSet<Plant>();
    }
}
