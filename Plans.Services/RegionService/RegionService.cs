namespace Plants.Services.RegionService
{
	using Data.Models.ApplicationUser;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;

	public class RegionService : IRegionService
	{
		private IRepositoryService _repository;
		private readonly IMapper _mapper;

		public RegionService(IRepositoryService repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		//public async Task CreateAsync(string regionName, string countryName)
		//{
		//	var region = _repository
		//		.AllReadOnly<Region>()
		//		.FirstOrDefault(x => x.Name == regionName);

		//	var country = _repository
		//		.AllReadOnly<Country>()
		//		.Include(x => x.Regions)
		//		.FirstOrDefault(x => x.Name == countryName);

		//	//tuk trqbva da opravq humidity

		//	if (country == null)
		//	{
		//		country = new Country()
		//		{
		//			Name = countryName
		//		};

		//		await _repository.AddAsync(country);
		//	}

		//	if (region == null || region.Country.Name != countryName)
		//	{
		//		region = new Region()
		//		{
		//			Name = regionName
		//		};

		//		await _repository.AddAsync(region);

		//		var humidity = await _openMeteoService.GetHumidityAsync(regionName);

		//		if (humidity != null)
		//		{
		//			//city.Humidity
		//		}
		//	}

		//	region.Country = country;
		//	country.Regions.Add(region);

		//	await _repository.SaveChangesAsync();
		//}

		public async Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync()
		{
			var cities = await _repository
				.AllReadOnly<Region>()
				.ToListAsync();

			var model = _mapper.Map<List<RegionViewModel>>(cities);

			return model;
		}
	}
}
