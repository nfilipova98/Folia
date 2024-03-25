namespace Plants.Services.UserService
{
	using Data.Models.ApplicationUser;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Plants.Data.Models.Pet;

	public class UserService : IUserService
	{
		private IRepositoryService _repository;
		private readonly IMapper _mapper;

		public UserService(IRepositoryService repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<FirstLoginViewModel> GetModels()
		{
			var cities = _repository.AllReadOnly<City>();
			var pets = _repository.AllReadOnly<Pet>();

			var citiesViewModels = _mapper.Map<IEnumerable<CityViewModel>>(cities);
			var petsViewModels = _mapper.Map<IEnumerable<PetViewModel>>(pets);

			var model = new FirstLoginViewModel()
			{
				Cities = citiesViewModels,
				Pets = petsViewModels,
			};

			return model;
		}
	}
}
