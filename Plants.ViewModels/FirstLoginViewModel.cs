namespace Plants.ViewModels
{
	using Data.Models.Enums;

	public class FirstLoginViewModel
	{
		public string ApplicationUserId { get; set; } = null!;

		public int CityId { get; set; }

		public IEnumerable<CityViewModel> Cities { get; set; } = new List<CityViewModel>();

		public bool Kids { get; set; }

		public FacingDirection Direction { get; set; }

		public Lifestyle Lifestyle { get; set; }

		public int PetIds { get; set; }

		public IEnumerable<PetViewModel> Pets { get; set; } = new List<PetViewModel>();
	}
}
