namespace Plants.ViewModels
{
	using Data.Models.Enums;
	using Models;

	public class FirstLoginViewModel
	{
		public string ApplicationUserId { get; set; } = string.Empty!;

		public int RegionId { get; set; }

		public IEnumerable<RegionViewModel> Regions { get; set; } = new List<RegionViewModel>();

		public bool Kids { get; set; }

		public Lifestyle Lifestyle { get; set; }

		public int? PetIds { get; set; }

		public IEnumerable<PetViewModel> Pets { get; set; } = new List<PetViewModel>();

		public ImageModel? ImageModel { get; set; }
	}
}
