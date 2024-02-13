namespace Plants.Services.BlobService
{
    using Interfaces;
    using Models;

    using Azure.Storage.Blobs;
    using System.Threading.Tasks;

    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task UploadImageAsync(FileInputModel fileInputModel)
        {
            var container = _blobServiceClient.GetBlobContainerClient("publicimages");
            var stream = fileInputModel.FormFile.OpenReadStream();

            await container.UploadBlobAsync(Guid.NewGuid().ToString(), stream);
        }
    }
}
