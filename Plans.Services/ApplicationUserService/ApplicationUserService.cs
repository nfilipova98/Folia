//namespace Plants.Services.ApplicationUserService
//{
//    using APIs.BlobService.Models;
//    using Azure.Storage.Blobs;
//    using static Constants.GlobalConstants.ApiConstants;
//    using Data.Models.ApplicationUser;
//    using RepositoryService;

//    using System.IO;
//    using System.Threading.Tasks;

//    public class ApplicationUserService : IApplicationUserService
//    {
//        private readonly IRepository _repository;
//        private readonly BlobServiceClient _blobServiceClient;

//        public ApplicationUserService(IRepository repository, BlobServiceClient blobServiceClient)
//        {
//            _repository = repository;
//            _blobServiceClient = blobServiceClient;
//        }

//        public async Task<string> UploadFileAsync(ImageModel model, string userId)
//        {
//            var blobClient = GetBlobClient(model.FormFile.Name);

//            using (var stream = model.FormFile.OpenReadStream())
//            {
//                await blobClient.UploadAsync(stream);
//            }

//            var user = await FindUserByIdAsync(userId);

//            if (user != null)
//            {
//                user.UserPictureUrl = blobClient.Uri.ToString();
//                await _repository.SaveChangesAsync();
//            }

//            return blobClient.Uri.ToString();
//        }

//        public async Task DownloadFileAsync(string fileName, string filePath)
//        {
//            var blobClient = GetBlobClient(fileName);
//            await blobClient.DownloadToAsync(filePath);
//        }

//        public async Task DeleteFileAsync(ImageModel model, string userId)
//        {
//            var filePath = model.ImageUrl;
//            var fileName = GetFileNameFromUrl(filePath);

//            var blobClient = GetBlobClient(fileName);
//            var isDeleted = await blobClient.DeleteIfExistsAsync();

//            var user = await FindUserByIdAsync(userId);

//            if (user != null && isDeleted)
//            {
//                user.UserPictureUrl = null;
//                await _repository.SaveChangesAsync();
//            }
//        }
//        public string GetImageUrl(string fileName)
//        {
//            var blobClient = GetBlobClient(fileName);
//            var imageUrl = blobClient.Uri.AbsoluteUri;

//            return imageUrl.ToString();
//        }

//        private BlobClient GetBlobClient(string fileName)
//        {
//            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(BlobContainerName);
//            return blobContainerClient.GetBlobClient(fileName);
//        }

//        private string GetFileNameFromUrl(string filePath)
//            => Path.GetFileName(filePath);

//        private async Task<ApplicationUser?> FindUserByIdAsync(string userId)
//           => await _repository.FindByIdAsync<ApplicationUser>(userId);

//    }
//}
