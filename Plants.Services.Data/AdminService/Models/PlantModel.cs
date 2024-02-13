namespace Plants.Services.Data.AdminService.Models
{
    using Data.Models.ApplicationUser;
    using Data.Models.Comment;
    using Data.Models.Enums;
    using Data.Models.Pet;
    using static Data.Models.Utilities.DataBaseConstants;
    using static Data.Models.Utilities.DataBaseConstants.PlantConstants;

    using System.ComponentModel.DataAnnotations;

    public class PlantModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(PlantNameMaxLenght,
            MinimumLength = PlantNameMinLenght,
            ErrorMessage = StringLenghtErrorMessage)]
        public required string Name { get; set; }

        [Display(Name = "Scientific Name")]
        [StringLength(PlantNameMaxLenght,
            MinimumLength = PlantNameMinLenght,
            ErrorMessage = StringLenghtErrorMessage)]
        public string? ScientificName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public required string ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [EnumDataType(typeof(Humidity))]
        public required Humidity Humidity { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [EnumDataType(typeof(Difficulty))]
        public required Difficulty Difficulty { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [EnumDataType(typeof(Lifestyle))]
        public required Lifestyle Lifestyle { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Kid Safe")]
        public required bool KidSafe { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public required bool Outdoor { get; set; }

        [Display(Name = "Trending")]
        public required bool IsTrending { get; set; }

        public ICollection<ApplicationUser> UsersLikedPlant { get; set; } = new HashSet<ApplicationUser>();

        public ICollection<ApplicationUser> Owners { get; set; } = new HashSet<ApplicationUser>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}
