namespace Plants.Services.CityService
{
	using APIs.OpenMeteoService;
	using Data.Models.ApplicationUser;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;

	public class CityService : ICityService
	{
		private IOpenMeteoService _openMeteoService;
		private IRepositoryService _repository;
		private readonly IMapper _mapper;

		public CityService(IOpenMeteoService openMeteoService, IRepositoryService repository, IMapper mapper)
		{
			_openMeteoService = openMeteoService;
			_repository = repository;
			_mapper = mapper;
		}

		//zashto kato se dobavq grad v darjavata me stava 
		public async Task CreateAsync(string cityName, string countryName)
		{
			var city = _repository
				.AllReadOnly<City>()
				.FirstOrDefault(x => x.Name == cityName);

			var country = _repository
				.AllReadOnly<Country>()
				.Include(x => x.Cities)
				.FirstOrDefault(x => x.Name == countryName);

			//tuk trqbva da opravq humidity

			if (country == null)
			{
				country = new Country()
				{
					Name = countryName
				};

				await _repository.AddAsync(country);
			}
			if (city == null)
			{
				city = new City()
				{
					Name = cityName,
					Country = country,
				};

				await _repository.AddAsync(city);
			}
			else
			{
				//greshka
			}

			await _openMeteoService.GetHumidityAsync(cityName, null, null);

			country.Cities.Add(city);

			await _repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<CityViewModel>> GetAllCitiesAsync()
		{
			var cities = await _repository
				.AllReadOnly<City>()
				.ToListAsync();

			var model = _mapper.Map<List<CityViewModel>>(cities);

			return model;
		}
	}
}
