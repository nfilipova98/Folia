namespace Plants.Controllers
{
	using Services.RegionService;

	public class RegionController : BaseController
	{
		private readonly IRegionService _regionService;

		public RegionController(IRegionService regionService)
		{
			_regionService = regionService;
		}
	}
}
