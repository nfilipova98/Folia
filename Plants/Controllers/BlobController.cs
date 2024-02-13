namespace Plants.Controllers
{
    using Services.BlobService.Interfaces;
    using Services.BlobService.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    public class BlobController : BaseController
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(FileInputModel fileInputModel)
        {
            await _blobService.UploadImageAsync(fileInputModel);

            return Ok();
        }
    }
}
