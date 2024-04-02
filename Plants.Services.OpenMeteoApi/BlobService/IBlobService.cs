namespace Plants.Services.APIs.BlobService
{
	using Models;

	public interface IBlobService
	{
		Task<string> UploadFileAsync(ImageModel file);
		Task DeleteFileAsync(string fileName, int id);
	}
}
