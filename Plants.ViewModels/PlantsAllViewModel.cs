namespace Plants.ViewModels
{
	using Models;

	public class PlantsAllViewModel : PagingViewModel
	{
		public IEnumerable<PlantAllViewModel> AllPlants { get; set; } = new List<PlantAllViewModel>();
    }
}
