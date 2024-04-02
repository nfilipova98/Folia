namespace Plants.Services.UserService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Data.Models.Pet;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;

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

		public async Task<Tier?> FindUserByIdAsync(string userId)
		{
			var user = await _repository.FindByIdAsync<ApplicationUser>(userId);

			return user?.Tier;
		}
	}
}
