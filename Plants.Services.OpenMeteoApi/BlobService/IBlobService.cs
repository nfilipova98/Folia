namespace Plants.Services.APIs.BlobService
{
    public interface IBlobService
    {
        Task<string> UploadFileAsync(ImageModel model, int id);
        //Task DownloadFileAsync(string fileName, string filePath);
        Task<bool> DeleteFileAsync(ImageModel model, int id);
        string GetImageUrl(string fileName);
    }
}
