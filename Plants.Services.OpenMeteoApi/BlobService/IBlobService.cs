namespace Plants.Services.APIs.BlobService
{
	using Plants.Models;
	using Models;

	using Microsoft.AspNetCore.Mvc;

	public interface IBlobService
	{
		Task<IActionResult> UploadFileAsync(ImageModel file, PlantEditOrAddViewModel model);
		Task<bool> DeleteFileAsync(ImageModel model, int id);
	}
}
