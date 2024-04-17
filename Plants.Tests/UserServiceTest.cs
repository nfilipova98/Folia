namespace Plants.Tests
{
	using Data;
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Data.Models.Pet;
	using Services.Mapping;
	using Services.RepositoryService;
	using Services.UserService;
	using ViewModels;

	using AutoMapper;
	using Azure.Storage.Blobs;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Diagnostics;
	using Moq;

	public class UserServiceTest
	{
		private IRepositoryService _repository;
		private IMapper _mapper;
		private Mock<BlobServiceClient> _blobServiceClientMock;
		private PlantsDbContext _dbContext;
		private IUserService _userService;

		private List<Pet> _pets;
		private List<ApplicationUser> _users;
		private List<Region> _regions;
		private UserConfiguration _userConfiguration;

		[OneTimeSetUp]
		public async Task Setup()
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
				}
			};
			_userConfiguration = new UserConfiguration()
			{
				ApplicationUserId = "e1675c68-7c88-40ba-8723-6c789f396f76",
				Kids = false,
				Lifestyle = Lifestyle.OnTheGo,
				Pets = new List<Pet>()
				{
					_pets[0]
				}
			};
			_users = new List<ApplicationUser>()
			{
				new ApplicationUser
				{
					Id = "8d16841e-7c17-44c5-b30d-5f10b43122c8",
					Tier = Tier.Seed,
					TierPoints = 0,
					IsFirstTimeLogin = false,
					UserConfigurationIsNull = true,
				},
				new ApplicationUser
				{
					Id = "e1675c68-7c88-40ba-8723-6c789f396f76",
					Tier = Tier.Sprout,
					TierPoints = 20,
					IsFirstTimeLogin = false,
					UserConfigurationIsNull = false,
					UserConfiguration = _userConfiguration
				},

			};

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

			_blobServiceClientMock = new Mock<BlobServiceClient>();

			var options = new DbContextOptionsBuilder<PlantsDbContext>()
		   .UseInMemoryDatabase(databaseName: "PlantInMemoryDb" + Guid.NewGuid().ToString())
		   .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
		   .Options;

			_dbContext = new PlantsDbContext(options);

			_dbContext.AddRange(_pets);
			_dbContext.AddRange(_userConfiguration);
			_dbContext.AddRange(_users);
			_dbContext.AddRange(_regions);
			await _dbContext.SaveChangesAsync();

			_repository = new Repository(_dbContext);
			_userService = new UserService(_repository, _mapper, _blobServiceClientMock.Object);
		}

		[OneTimeTearDown]
		public async Task Teardown()
		{
			await _dbContext.Database.EnsureDeletedAsync();
			await _dbContext.DisposeAsync();
		}

		[Test]
		public async Task Test_GetModels_WithUserId_ReturnsCorrectModel()
		{
			string userId = _users[0].Id;
			var result = await _userService.GetModels(userId);

			Assert.That(_pets.Count(), Is.EqualTo(result.Pets.Count()));
			Assert.That(_regions.Count(), Is.EqualTo(result.Regions.Count()));
			Assert.That(result, Is.TypeOf<ProfileViewModel>());
		}

		[Test]
		public async Task Test_GetModels_WithUserId_ReturnsCorrectModel_With_UserConfiguration()
		{
			string userId = _users[1].Id;
			var result = await _userService.GetModels(userId);

			Assert.That(_pets.Count(), Is.EqualTo(result.Pets.Count()));
			Assert.That(_regions.Count(), Is.EqualTo(result.Regions.Count()));
			Assert.That(result.Kids, Is.EqualTo(_users[1].UserConfiguration.Kids));
			Assert.That(result.Lifestyle, Is.EqualTo(_users[1].UserConfiguration.Lifestyle));
			Assert.That(result, Is.TypeOf<ProfileViewModel>());
		}
	}
}
