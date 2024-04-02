namespace Plants.ViewModels
{
	using Data.Models.Enums;
	using Models;

	using System.ComponentModel;

	public class PlantsAllViewModel : PagingViewModel
	{
		public IEnumerable<PlantAllViewModel> AllPlants { get; set; } = new List<PlantAllViewModel>();

		public string? SearchTerm { get; set; } = string.Empty;

		public Lifestyle? Lifestyle { get; set; }

		public Difficulty? Difficulty { get; set; }

		[DisplayName("Kid Safe")]
		public bool? KidSafe { get; set; }

		public IEnumerable<int>? PetIds { get; set; } = new List<int>();

		public IEnumerable<PetViewModel>? Pets { get; set; } = new List<PetViewModel>();

		//public string Location { get; set; }
	}
}
