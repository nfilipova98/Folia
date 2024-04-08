namespace Plants.Services.AboutService
{
	using Data.Models.ApplicationUser;
    using Data.Models.Comment;
	using Data.Models.Plant;
	using Models;
	using RepositoryService;

	using AutoMapper;

    public class AboutService : IAboutService
	{
		private readonly IRepositoryService _repository;
		private readonly IMapper _mapper;

		public AboutService(IRepositoryService repository, IMapper mapper)
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
				CommentsCount = _repository.AllReadOnly<Comment>().Count(),
				CitiesCount = _repository.AllReadOnly<Region>().Count(),
			};

			var model = _mapper.Map<AboutViewModel>(data);

			return model;
		}
	}
}
