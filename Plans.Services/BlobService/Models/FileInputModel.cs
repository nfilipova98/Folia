namespace Plants.Services.BlobService.Models
{
    using Microsoft.AspNetCore.Http;

    public class FileInputModel
    {
        public IFormFile FormFile { get; set; }
    }
}
