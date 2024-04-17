namespace Plants.Tests
{
	using Data;
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Services.LayoutService;
	using Services.RepositoryService;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Diagnostics;

	public class LayoutServiceTest
	{
		private IRepositoryService _repository;
		private PlantsDbContext _dbContext;
		private ILayoutService _layoutService;

		private List<ApplicationUser> _users;

		[OneTimeSetUp]
		public async Task Setup()
		{
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
					UserConfiguration = new UserConfiguration
					{
						Kids = false,
						Lifestyle = Lifestyle.OnTheGo,
						UserPictureUrl = "https://fakeImage.jpg",
					}
				},
			};

			var options = new DbContextOptionsBuilder<PlantsDbContext>()
		   .UseInMemoryDatabase(databaseName: "PlantInMemoryDb" + Guid.NewGuid().ToString())
		   .Options;

			_dbContext = new PlantsDbContext(options);

			_dbContext.AddRange(_users);
			await _dbContext.SaveChangesAsync();

			_repository = new Repository(_dbContext);
			_layoutService = new LayoutService(_repository);
		}

		[OneTimeTearDown]
		public async Task Teardown()
		{
			await _dbContext.Database.EnsureDeletedAsync();
			await _dbContext.DisposeAsync();
		}

		[TestCase("8d16841e-7c17-44c5-b30d-5f10b43122c8")]
		[TestCase("e1675c68-7c88-40ba-8723-6c789f396f76")]
		[TestCase("1")]
		public async Task Test_FindUsersTierByIdAsync_ShouldReturnCorrectTier(string userId)
		{
			var result = await _layoutService.FindUsersTierByIdAsync(userId);

			var expected = _users.FirstOrDefault(x => x.Id == userId)?.Tier;

			Assert.That(expected, Is.EqualTo(result));
		}

		[TestCase("8d16841e-7c17-44c5-b30d-5f10b43122c8")]
		[TestCase("e1675c68-7c88-40ba-8723-6c789f396f76")]
		[TestCase("2")]
		public async Task Test_FindUsersPictureByIdAsync_ShouldReturnCorrectPicture(string userId)
		{
			var result = await _layoutService.FindUsersPictureByIdAsync(userId);

			var expected = _users.FirstOrDefault(x => x.Id == userId)?.UserConfiguration?.UserPictureUrl;

			Assert.That(expected, Is.EqualTo(result));
		}

		[Test]
		public async Task Test_GetUserConfiguration_ShouldReturnCorrectUserConfiguration()
		{
			var userId = _users[1].Id;
			var result = await _layoutService.GetUserConfiguration(userId);
			var expected = _users.FirstOrDefault(x => x.Id == userId)?.UserConfiguration;

			Assert.That(expected.Lifestyle, Is.EqualTo(result.Lifestyle));
			Assert.That(expected.Id, Is.EqualTo(result.Id));
			Assert.That(expected.RegionId, Is.EqualTo(result.RegionId));
		}

		[Test]
		public async Task Test_GetUserConfiguration_ShouldReturnNull()
		{
			const string userId = "1";
			var result = await _layoutService.GetUserConfiguration(userId);

			Assert.That(result, Is.Null);
		}
	}
}