namespace Plants.ViewModels
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel;

    public class ImageModel
    {
        public string ImageUrl { get; set; } = string.Empty;

        [DisplayName("Image")]
        public IFormFile? FormFile { get; set; }
    }
}
