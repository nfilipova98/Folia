namespace Plants.Data.Models.Pet
{
    using ApplicationUser;
    using Plant;
	using static Services.Constants.GlobalConstants.PetConstants;

	using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Pet
    {
		[Comment("Identifier")]
		public int Id { get; set; }

		[Comment("Pet type")]
		[StringLength(PetNameMaxLenght)]
        public required string Name { get; set; }

        /// <summary>
        /// Information about the plants that may cause bad reactions/are not recommended.
        /// </summary>
        public ICollection<Plant> Plants { get; set; } = new HashSet<Plant>();

        /// <summary>
        /// Information about the User's pets
        /// </summary>
        public ICollection<UserConfiguration> Users { get; set; } = new HashSet<UserConfiguration>();
    }
}
