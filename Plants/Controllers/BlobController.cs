//namespace Plants.Controllers
//{
//    using Services.APIs.BlobService.Interfaces;
//    using Data;

//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;
//    using Plants.Services.APIs.BlobService.Models;

//    public class BlobController : BaseController
//    {
//        private readonly IBlobService _blobService;
//        private readonly PlantsDbContext _context;

//        public BlobController(IBlobService blobService, PlantsDbContext context)
//        {
//            _blobService = blobService;
//            _context = context;
//        }

//        [AllowAnonymous]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<IActionResult> UploadFile(ImageModel file)
//        {
//            if (file == null || file.FormFile.Length == 0)
//            {
//                return BadRequest();
//            }

//            var fileName = Guid.NewGuid().ToString();
//            using var fileStream = file.FormFile.OpenReadStream();
//            var fileUrl = await _blobService.UploadFileAsync(fileStream, fileName);

//            return Ok(new { FileUrl = fileUrl });
//        }

//        [AllowAnonymous]
//        public async Task<IActionResult> DownloadFile(string fileName)
//        {
//            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//            string filePath = Path.Combine(desktopPath, fileName);

//            await _blobService.DownloadFileAsync(fileName, filePath);

//            return PhysicalFile(filePath, "application/octet-stream", fileName);
//        }

//        [AllowAnonymous]
//        public async Task<IActionResult> DeleteFile(int id)
//        {
//            await _blobService.DeleteFileAsync(id);
//            return NoContent();
//        }

//        [AllowAnonymous]
//        public async Task<IActionResult> GetImageUrl(string fileName, int id)
//        {
//            var imageUrl = _blobService.GetImageUrl(fileName);

//            var plant = _context.Plants
//                .FirstOrDefault(x => x.Id == id);

//            if (plant == null)
//            {
//                return View();
//            }

//            plant.ImageUrl = imageUrl;
//            await _context.SaveChangesAsync();

//            return Ok();
//        }
//    }
//}