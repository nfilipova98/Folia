namespace Plants.Services.RegionService
{
    using Data.Models.ApplicationUser;
    using RepositoryService;
    using static Constants.GlobalConstants.ApiConstants;
    using ViewModels;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using OpenMeteo;
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

		public async Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync()
		{
			var cities = await _repository
				.AllReadOnly<Region>()
				.OrderBy(x => x.Name)
				.ToListAsync();

			var model = _mapper.Map<List<RegionViewModel>>(cities);

			return model;
		}

		public async Task<double?> GetHumidityAsync(string region)
		{
			OpenMeteoClient client = new();

			HourlyOptions hourlyOptions = new()
			{
				HourlyOptionsParameter.relativehumidity_2m,
			};

			WeatherForecastOptions weatherForecastOptions = new()
			{
				Hourly = hourlyOptions,
				Past_Days = PastDays
			};

			WeatherForecast weatherForecast = await client.QueryAsync(region, weatherForecastOptions);

			var percentage = weatherForecast?.Hourly?.Relativehumidity_2m?.Average();

			return percentage;
		}
	}
}
