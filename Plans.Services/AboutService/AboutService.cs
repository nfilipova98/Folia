namespace Plants.Services.AboutService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Plant;
	using Models;
	using RepositoryService;

	using AutoMapper;

	public class AboutService : IAboutService
	{
		private readonly IRepository _repository;
		private readonly IMapper _mapper;

		public AboutService(IRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public AboutViewModel GetCounts()
		{
			var data = new AboutViewModel() 
			{ 
				PlantsCount = _repository.AllReadOnly<Plant>().Count(),
				UsersCount = _repository.AllReadOnly<ApplicationUser>().Count(),
			};

			var model = _mapper.Map<AboutViewModel>(data);

			return model;
		}
	}
}
