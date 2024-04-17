namespace Plants.Tests
{
	using Data;
	using Data.Models.ApplicationUser;
	using Services.Mapping;
	using Services.RegionService;
	using Services.RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;

	public class RegionServiceTest
	{
		[TestFixture]
		public class AboutServiceTests
		{
			private IRepositoryService _repository;
			private IMapper _mapper;
			private IRegionService _regionService;
			private PlantsDbContext _dbContext;

			private List<Region> _regions;

			[OneTimeSetUp]
			public async Task SetUp()
			{
				_regions = new List<Region>()
			{
				new Region
				{
					Id = 1,
					Name = "Varna",
					CountryId = 1,
				},
				new Region
				{
					Id = 2,
					Name = "Sofia",
					CountryId = 1,
				},
				new Region
				{
					Id = 3,
					Name = "Plovdiv",
					CountryId = 1,
				},
				new Region
				{
					Id = 4,
					Name = "Veliko Tarnovo",
					CountryId = 1,
				}
			};

				var myProfile = new AutoMapperProfile();
				var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
				_mapper = new Mapper(configuration);

				var options = new DbContextOptionsBuilder<PlantsDbContext>()
			   .UseInMemoryDatabase(databaseName: "PlantInMemoryDb" + Guid.NewGuid().ToString())
				.Options;

				_dbContext = new PlantsDbContext(options);
				_dbContext.AddRange(_regions);
				await _dbContext.SaveChangesAsync();

				_repository = new Repository(_dbContext);
				_regionService = new RegionService(_repository, _mapper);
			}

			[OneTimeTearDown]
			public async Task Teardown()
			{
				await _dbContext.Database.EnsureDeletedAsync();
				await _dbContext.DisposeAsync();
			}

			[Test]
			public async Task Test_GetAllPetsAsync_ShouldReturnAllPets()
			{
				var result = await _regionService.GetAllRegionsAsync();

				Assert.That(result, Is.Not.Null);
				Assert.That(_regions.Count(), Is.EqualTo(result.Count()));
				Assert.That(result, Is.TypeOf<List<RegionViewModel>>());
			}
		}
	}
}
