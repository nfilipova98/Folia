namespace Plants.Models
{
    using static Services.Constants.GlobalConstants.ErrorMessages;

    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class ImageModel
    {
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Image")]
        public IFormFile FormFile { get; set; }
    }
}
