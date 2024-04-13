namespace Plants.ViewModels
{
    using Data.Models.Enums;
    using System.ComponentModel;

    public class PlantsAllViewModel : PagingViewModel
    {
        public IEnumerable<PlantAllViewModel> AllPlants { get; set; } = new List<PlantAllViewModel>();

        public string? SearchTerm { get; set; }

        public Lifestyle? Lifestyle { get; set; }

        public Difficulty? Difficulty { get; set; }

        [DisplayName("Kid Safe")]
        public bool? KidSafe { get; set; }

        public bool? PetSafe { get; set; }

        public int? RegionId { get; set; }

        public IEnumerable<RegionViewModel>? Regions { get; set; } = new List<RegionViewModel>();
    }
}
