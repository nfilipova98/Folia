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

		//[HttpGet]
		//[Authorize(Roles = Admin)]
		//public async Task<IActionResult> Add()
		//{
		//	var model = new RegionAddViewModel();

		//	return View(model);
		//}

		//[HttpPost]
		//[Authorize(Roles = Admin)]
		//public async Task<IActionResult> Add(RegionAddViewModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return View(model);
		//	}

		//	await _regionService.CreateAsync(model.RegionName, model.CountryName);

		//	return RedirectToAction("Index", "Home");
		//}
	}
}
