namespace Plants.Data.Models.ApplicationUser
{
    using Enums;
	using Pet;

	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;

	public class UserConfiguration 
    {
		[Comment("Identifier")]
		public int Id { get; set; }

		[Comment("User identifier")]
		[Required]
		public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

		[Comment("Region identifier")]
		public int? RegionId { get; set; }
        public Region? Region { get; set; }

        public bool Kids { get; set; }

		[Comment("Profile picture")]
		public string? UserPictureUrl { get; set; }

		public Lifestyle Lifestyle { get; set; }

        /// <summary>
        /// List of the User's pets
        /// </summary>
        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}