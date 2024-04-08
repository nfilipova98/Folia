namespace Plants.ViewModels
{
	using Data.Models.Enums;
	using Models;

	public class FirstLoginViewModel
	{
		public string ApplicationUserId { get; set; } = string.Empty!;

		public int CityId { get; set; }

		public IEnumerable<CityViewModel> Cities { get; set; } = new List<CityViewModel>();

		public bool Kids { get; set; }

		public Lifestyle Lifestyle { get; set; }

		public int? PetIds { get; set; }

		public IEnumerable<PetViewModel> Pets { get; set; } = new List<PetViewModel>();

		public ImageModel? ImageModel { get; set; }
	}
}
