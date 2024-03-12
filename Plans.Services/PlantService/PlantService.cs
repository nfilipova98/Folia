namespace Plants.Services.PlantService
{
    using APIs.BlobService;
    using Azure.Storage.Blobs;
    using Data.Models.Plant;
    using static Constants.GlobalConstants.ApiConstants;
    using RepositoryService;

    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class PlantService : IPlantService
    {
        private readonly IRepository _repository;
        private readonly BlobServiceClient _blobServiceClient;

        public PlantService(IRepository repository, BlobServiceClient blobServiceClient)
        {
            _repository = repository;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadFileAsync(ImageModel model, int id)
        {
            var blobClient = GetBlobClient(model.FormFile.FileName);

            using (var stream = model.FormFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            return blobClient.Uri.ToString();
        }

        public async Task DownloadFileAsync(string fileName, string filePath)
        {
            var blobClient = GetBlobClient(fileName);
            await blobClient.DownloadToAsync(filePath);
        }

        public async Task<bool> DeleteFileAsync(ImageModel model, int id)
        {
            var filePath = model.ImageUrl;

            var blobClient = GetBlobClient(model.FormFile.FileName);
            var isDeleted = await blobClient.DeleteIfExistsAsync();

            return isDeleted;
        }

        public string GetImageUrl(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            var imageUrl = blobClient.Uri.AbsoluteUri;

            return imageUrl.ToString();
        }

        private BlobClient GetBlobClient(string fileName)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
            return blobContainerClient.GetBlobClient(fileName);
        }
    }
}
