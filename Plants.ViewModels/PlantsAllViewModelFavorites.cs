namespace Plants.ViewModels
{
	using Models;

	public class PlantsAllViewModelFavorites : PagingViewModel
	{
		public IEnumerable<PlantAllViewModel> AllPlants { get; set; } = new List<PlantAllViewModel>();
	}
}
