namespace Plants.Services.APIs.BlobService
{
    using static Services.Constants.GlobalConstants.ErrorMessages;

    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class ImageModel
    {
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Image")]
        public IFormFile FormFile { get; set; }
    }
}
