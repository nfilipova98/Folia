﻿namespace Plants.Services.PetService
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

		public async Task<IEnumerable<PetViewModel>> GetAllPetsAsync()
		{
			var pets = await _repository
				.AllReadOnly<Pet>()
				.ToListAsync();

			var model = _mapper.Map<List<PetViewModel>>(pets);

			return model;
		}
	}
}