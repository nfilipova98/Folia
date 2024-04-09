namespace Plants.Services.RegionService
{
	using Data.Models.ApplicationUser;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using OpenMeteo;

	public class RegionService : IRegionService
	{
		private IRepositoryService _repository;
		private readonly IMapper _mapper;

		public RegionService(IRepositoryService repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync()
		{
			var cities = await _repository
				.AllReadOnly<Region>()
				.OrderBy(x => x.Name)
				.ToListAsync();

			var model = _mapper.Map<List<RegionViewModel>>(cities);

			return model;
		}

		public Task<IEnumerable<Region>> GetHumidityAsync(IEnumerable<Region> regions)
		{
			throw new NotImplementedException();
			//OpenMeteoClient client = new();

			//			HourlyOptions hourlyOptions = new()
			//			{
			//				HourlyOptionsParameter.relativehumidity_2m,
			//			};

			//			WeatherForecastOptions weatherForecastOptions = new()
			//			{
			//				Hourly = hourlyOptions,
			//				Past_Days = PastDays
			//			};

			//			WeatherForecast weatherForecast = await client.QueryAsync(location, weatherForecastOptions);

			//				var percentage = weatherForecast.Hourly?.Relativehumidity_2m?.Average();

			//				if (percentage == null)
			//				{
			//					item.Humidity = null;
			//				}
			//				else if (percentage >= 0 && percentage <= 25)
			//				{
			//					item.Humidity = Humidity.Low;
			//				}
			//				else if (percentage > 25 && percentage <= 50)
			//				{
			//					item.Humidity = Humidity.Moderate;
			//				}
			//				else if (percentage > 50 && percentage <= 75)
			//				{
			//					item.Humidity = Humidity.High;
			//				}
			//				else if (percentage > 75 && percentage <= 100)
			//				{
			//					item.Humidity = Humidity.VeryHigh;
			//				}
			//			}

			//			return regions;
			//		}
		}
	}
}
