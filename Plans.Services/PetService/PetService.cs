namespace Plants.Services.PetService
{
	using Data.Models.Pet;
	using ViewModels;
	using RepositoryService;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using SendGrid.Helpers.Errors.Model;

	public class PetService : IPetService
	{
		private IRepositoryService _repository;
		private readonly IMapper _mapper;

		public PetService(IRepositoryService repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PetViewModel>> GetAllPetsAsync()
		{
			var pets = await _repository
				.AllReadOnly<Pet>()
				.ToListAsync();

			var model = _mapper.Map<List<PetViewModel>>(pets);

			return model;
		}

		public async Task CreateAsync(string name)
		{
			var model = _repository
				.AllReadOnly<Pet>()
				.FirstOrDefault(x => x.Name == name);

			if (model != null)
			{
				throw new InvalidOperationException();
			}

			var pet = new Pet()
			{
				Name = name
			};

			await _repository.AddAsync(pet);
			await _repository.SaveChangesAsync();
		}
	}
}
