namespace Plants.Tests
{
	using Data;
	using Data.Models.ApplicationUser;
	using Data.Models.Comment;
	using Data.Models.Enums;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using Services.AboutService;
	using Services.RepositoryService;
	using Services.Mapping;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;

	[TestFixture]
	public class AboutServiceTests
	{
		private IRepositoryService _repository;
		private IMapper _mapper;
		private IAboutService _aboutService;
		private PlantsDbContext _dbContext;

		private List<Plant> _plants;
		private List<ApplicationUser> _users;
		private List<Region> _regions;
		private List<Comment> _comments;

		[OneTimeSetUp]
		public async Task SetUp()
		{
			_plants = new List<Plant>()
			{
				new Plant
				{
				Id = 1,
				Name = "Buddhist Pine",
				ScientificName = "Podocarpus Macrophyllus",
				Difficulty = Difficulty.Easy,
				Humidity = Humidity.Moderate,
				KidSafe = true,
				Lifestyle = Lifestyle.OnTheGo,
				IsTrending = true,
				ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/0.jpg",
				Description = "Buddhist Pine, scientifically known as Podocarpus Macrophyllus, is an easy-care evergreen shrub that delights gardeners and plant enthusiasts alike. With its lush green foliage and graceful, upright growth habit, this plant adds a touch of elegance to any outdoor space. Its botanical name, Podocarpus Macrophyllus, reflects its large, glossy leaves that bring a refreshing aesthetic to gardens and landscapes. Thriving in moderate humidity levels, the Buddhist Pine is a versatile plant that adapts well to various environmental conditions, making it suitable for a wide range of climates. Its low maintenance nature makes it an excellent choice for both novice and experienced gardeners seeking a hassle-free addition to their outdoor greenery. One of the notable features of the Buddhist Pine is its child-friendly nature, making it a safe and worry-free option for households with children or pets. Its non-toxic properties ensure peace of mind for parents and pet owners alike. Embracing a traveler lifestyle, this plant is perfect for those who frequently find themselves on the move. Its adaptability to different outdoor settings and minimal care requirements make it an ideal companion for globetrotters and outdoor enthusiasts seeking a touch of greenery wherever they go. As an outdoor plant, the Buddhist Pine thrives in natural sunlight, flourishing under open skies and gentle breezes. Whether planted as a standalone specimen or incorporated into garden beds and borders, its presence adds a timeless charm to any outdoor setting. In line with current trends, the Buddhist Pine has gained popularity among gardening enthusiasts and landscape designers alike. Its classic appeal and easygoing nature make it a sought-after choice for those looking to enhance their outdoor spaces with a touch of understated elegance.",
				Pets = new List<Pet>()
				{
					new Pet { Id = 3, Name = "Dog" },
					new Pet { Id = 4, Name = "Cat" }
				}
				},
				new Plant
				{
					Id = 2,
					Name = "Spider plant",
					ScientificName = "Chlorophytum comosum",
					Difficulty = Difficulty.Easy,
					Humidity = Humidity.Moderate,
					KidSafe = true,
					Lifestyle = Lifestyle.OnTheGo,
					IsTrending = false,
					ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/13.jpg",
					Description = "The Spider Plant, scientifically known as Chlorophytum comosum, is a resilient and popular choice for both beginner and seasoned plant enthusiasts alike. True to its name, its slender, arching leaves resemble spider legs, lending an elegant and distinctive appearance to any indoor space. Thriving in moderate humidity levels, the Spider Plant is relatively undemanding when it comes to care, making it an ideal addition to households with varying environmental conditions. Its preference for moderate humidity levels makes it adaptable to a wide range of indoor environments. One of its standout features is its suitability for homes with children, as it is considered safe for kids and pets. This characteristic, combined with its easy care requirements, makes it a top choice for families looking to introduce greenery into their living spaces without worry. For individuals with active lifestyles or frequent travelers, the Spider Plant is particularly appealing. Its easygoing nature means it can withstand periods of neglect and irregular watering, making it a reliable companion for those who may be away from home frequently. Although the Spider Plant is primarily an indoor plant, its versatility allows it to thrive in a variety of indoor settings, from bright, well-lit rooms to those with lower light conditions. Its adaptability further enhances its appeal, as it can easily find a place in different areas of the home, bringing a touch of natural beauty wherever it's placed."
				},
				new Plant
				{
					Id = 3,
					Name = "Rubber fig",
					ScientificName = "Ficus elastica",
					Difficulty = Difficulty.Easy,
					Humidity = Humidity.High,
					KidSafe = false,
					Lifestyle = Lifestyle.OnTheGo,
					IsTrending = false,
					ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/10.jpg",
					Description = "The Rubber Fig, scientifically known as Ficus elastica, is a stunning addition to any indoor garden. With its glossy, deep green leaves and sturdy, upright growth habit, it adds a touch of elegance to any room it inhabits. This plant is a perfect choice for both novice and experienced plant parents due to its easy-care nature. Its resilience and adaptability make it an excellent option for those new to plant care or those seeking low-maintenance greenery. Thriving in environments with high humidity levels, the Rubber Fig is ideal for spaces where moisture levels can be easily controlled, such as bathrooms or kitchens. Its preference for high humidity ensures that it remains healthy and vibrant even in dry indoor environments. Families with children or pets will appreciate the Rubber Fig's safe nature, as it is non-toxic and considered kid-friendly. This characteristic allows it to be placed in any room of the house without concern for the safety of curious little ones or furry friends. For individuals leading busy lives or frequent travelers, the Rubber Fig is an excellent companion. Its ability to tolerate occasional neglect and irregular watering makes it a resilient choice for those who may not always have time to devote to plant care. While primarily an indoor plant, the Rubber Fig can be placed in a variety of indoor settings, from bright, sunlit rooms to areas with lower light levels. Its versatility in light requirements allows it to thrive in different environments, making it a versatile addition to any indoor space.",
				},
				new Plant
				{
					Id = 4,
					Name = "Areca palm",
					ScientificName = "Dypsis lutescens",
					Difficulty = Difficulty.Easy,
					Humidity = Humidity.Moderate,
					KidSafe = true,
					Lifestyle = Lifestyle.OnTheGo,
					IsTrending = true,
					ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/12.jpg",
					Description = "The Areca Palm, scientifically known as Dypsis lutescens, brings a touch of tropical elegance to both indoor and outdoor spaces. With its graceful fronds and slender, bamboo-like stems, it adds a sense of lushness and tranquility to any environment it graces. This palm species is an excellent choice for plant enthusiasts of all levels, as it is relatively easy to care for and maintain. Its adaptable nature allows it to thrive in various conditions, making it a popular option for both beginners and seasoned gardeners alike.Preferring moderate humidity levels, the Areca Palm is well-suited to indoor environments where humidity can be controlled. However, its versatility also extends to outdoor settings, where it can flourish in mild climates with moderate humidity levels. Families with children and pets will appreciate the Areca Palm's non-toxic nature, as it poses no harm if accidentally ingested. Its safety makes it a fantastic choice for households with curious little ones or furry companions. For individuals with active lifestyles or frequent travelers, the Areca Palm is an ideal companion. Its low-maintenance requirements and resilience to occasional neglect make it a reliable option for those who may not always have time to devote to plant care. While it can thrive both indoors and outdoors, the Areca Palm truly shines when given the opportunity to bask in natural sunlight. Its ability to flourish in outdoor settings makes it a versatile choice for landscaping, adding a touch of tropical beauty to gardens, patios, and balconies alike."
				},
				new Plant
				{
					Id = 5,
					Name = "Watermelon Peperomia",
					ScientificName = "Peperomia argyreia",
					Difficulty = Difficulty.Easy,
					Humidity = Humidity.High,
					KidSafe = false,
					Lifestyle = Lifestyle.SemiActive,
					IsTrending = false,
					ImageUrl = "https://softuniproject.blob.core.windows.net/publicimages/11.jpg",
					Description = "The Watermelon Peperomia, scientifically known as Peperomia argyreia, is a charming and distinctive houseplant that adds a pop of color and personality to any indoor space. With its striking foliage resembling the rind of a watermelon, this plant is sure to capture attention and become a favorite among plant enthusiasts. Caring for the Watermelon Peperomia is a delight, as it falls under the category of easy-care plants. Its low-maintenance nature makes it an excellent choice for both novice and experienced plant parents alike. With just a little attention, it will thrive and continue to display its vibrant beauty. This plant thrives in environments with high humidity levels, making it well-suited for areas such as bathrooms or kitchens where moisture levels tend to be higher. Its preference for humidity ensures that its lush leaves remain healthy and vibrant, adding a refreshing touch to indoor spaces. Families with children and pets can enjoy the Watermelon Peperomia worry-free, as it is considered safe for both humans and animals. Its non-toxic properties make it a fantastic choice for households with curious little ones or furry companions. The Watermelon Peperomia fits seamlessly into the lifestyle of those who fall in between busy and laid-back. Its moderate care requirements mean that it can thrive with regular but not overly demanding attention, making it an ideal choice for individuals with varied schedules and commitments. While primarily an indoor plant, the Watermelon Peperomia does not thrive in outdoor settings. Its preference for stable indoor conditions makes it unsuitable for placement outside, but its captivating beauty ensures that it will become a cherished addition to any indoor garden or plant collection."
				},
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
					LikedPlants = new List<Plant>()
					{
						_plants[0],
					}
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
			_comments = new List<Comment>()
			{
				new Comment
				{
					Id = 1,
					Content = "This is a comment",
					ApplicationUserId = "8d16841e-7c17-44c5-b30d-5f10b43122c8",
					CreatedOn = DateTime.UtcNow,
					PlantId = 2
				},
			};

			var myProfile = new AutoMapperProfile();
			var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
			_mapper = new Mapper(configuration);

			var options = new DbContextOptionsBuilder<PlantsDbContext>()
		   .UseInMemoryDatabase(databaseName: "PlantInMemoryDb" + Guid.NewGuid().ToString())
			.Options;

			_dbContext = new PlantsDbContext(options);
			_dbContext.AddRange(_plants);
			_dbContext.AddRange(_users);
			_dbContext.AddRange(_regions);
			_dbContext.AddRange(_comments);
			await _dbContext.SaveChangesAsync();

			_repository = new Repository(_dbContext);
			_aboutService = new AboutService(_repository, _mapper);
		}

		[OneTimeTearDown]
		public async Task Teardown()
		{
			await _dbContext.Database.EnsureDeletedAsync();
			await _dbContext.DisposeAsync();
		}

		[Test]
		public async Task Test_GetCounts_ShouldReturnCorrectCounts()
		{
			var result = _aboutService.GetCounts();

			Assert.That(_plants.Count, Is.EqualTo(result.PlantsCount));
			Assert.That(_users.Count, Is.EqualTo(result.UsersCount));
			Assert.That(_comments.Count, Is.EqualTo(result.CommentsCount));
			Assert.That(_regions.Count, Is.EqualTo(result.RegionsCount));
			Assert.That(result, Is.TypeOf<AboutViewModel>());
		}
	}
}
