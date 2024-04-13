namespace Plants.Data.Models.Comment
{
    using ApplicationUser;
    using Data.Models.Plant;
	using static Services.Constants.GlobalConstants.CommentConstants;

	using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
		[Comment("Identifier")]
		public int Id { get; set; }

        [StringLength(CommentContentMaxLenght)]
		[Comment("Comment content")]
		public required string Content { get; set; }

		public required DateTime CreatedOn { get; set; }

		[Comment("User identifier")]
		public required string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; } = null!;

		[Comment("Plant identifier")]
		public required int PlantId { get; set; }
		public Plant Plant { get; set; } = null!;
	}
}
