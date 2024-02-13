namespace Plants.Services.BlobService.Interfaces
{
    using Plants.Services.BlobService.Models;

    public interface IBlobService
    {
        Task UploadImageAsync(FileInputModel fileInputModel);
    }
}
