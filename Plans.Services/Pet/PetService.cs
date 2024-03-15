namespace Plants.Services.Pet
{
	using Data.Models.Pet;
	using Models;
	using RepositoryService;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;

	public class PetService : IPetService
	{
		private IRepository _repository;
		private readonly IMapper _mapper;

		public PetService(IRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PetViewModel>> GetPetsAsync()
		{
			var pets = await _repository.AllReadOnly<Pet>()
				.ToListAsync();

			var model = _mapper.Map<IEnumerable<PetViewModel>>(pets);

			return model;
		}
	}
}
