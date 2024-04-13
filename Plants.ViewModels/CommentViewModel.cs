namespace Plants.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;
        public string ApplicationUserName { get; set; } = string.Empty;

        public string? ApplicationUserPictureUrl { get; set; }
        public int PlantId { get; set; }
    }
}