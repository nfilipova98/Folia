namespace Plants.Tests
{
	using Data;
	using Data.Models.Pet;
	using Services.Mapping;
	using Services.PetService;
	using Services.RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;

	public class PetServiceTest
	{
		[TestFixture]
		public class AboutServiceTests
		{
			private IRepositoryService _repository;
			private IMapper _mapper;
			private IPetService _petService;
			private PlantsDbContext _dbContext;

			private List<Pet> _pets;

			[OneTimeSetUp]
			public async Task SetUp()
			{
				_pets = new List<Pet>()
			{
				new Pet
				{
					Id = 1,
					Name = "Rabbit"
				},
				new Pet
				{
					Id = 2,
					Name = "Bird"
				},
				new Pet
				{
					Id = 3,
					Name = "Dog"
				},
				new Pet
				{
					Id = 4,
					Name = "Cat"
				}
			};

				var myProfile = new AutoMapperProfile();
				var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
				_mapper = new Mapper(configuration);

				var options = new DbContextOptionsBuilder<PlantsDbContext>()
			   .UseInMemoryDatabase(databaseName: "PlantInMemoryDb" + Guid.NewGuid().ToString())
				.Options;

				_dbContext = new PlantsDbContext(options);
				_dbContext.AddRange(_pets);
				await _dbContext.SaveChangesAsync();

				_repository = new Repository(_dbContext);
				_petService = new PetService(_repository, _mapper);
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
				var result = await _petService.GetAllPetsAsync();

				Assert.That(result, Is.Not.Null);
				Assert.That(_pets.Count(), Is.EqualTo(result.Count()));
				Assert.That(result, Is.TypeOf<List<PetViewModel>>());
			}

			[Test]
			public async Task Test_CreateAsync_Should_Create_Pet()
			{
				const string petName = "Fish";

				await _petService.CreateAsync(petName);

				var expected = _dbContext.Pets.FirstOrDefault(x => x.Name == petName);

				Assert.That(expected, Is.Not.Null);
				Assert.That(expected.Name, Is.EqualTo(petName));
			}

			[Test]
			public async Task Test_CreateAsync_Throws_Exception()
			{
				const string petName = "Dog";

				Assert.ThrowsAsync<InvalidOperationException>(async () => await _petService.CreateAsync(petName));
			}
		}
	}
}
