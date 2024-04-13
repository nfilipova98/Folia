namespace Plants.ViewModels
{
    using Data.Models.Enums;
    public class ProfileViewModel
    {
        public string ApplicationUserId { get; set; } = string.Empty!;

        public int RegionId { get; set; }

        public IEnumerable<RegionViewModel> Regions { get; set; } = new List<RegionViewModel>();

        public bool Kids { get; set; }

        public Lifestyle Lifestyle { get; set; }

        public List<int>? PetIds { get; set; } = new List<int>();

        public IEnumerable<PetViewModel> Pets { get; set; } = new List<PetViewModel>();

        public ImageModel? ImageModel { get; set; }
    }
}
