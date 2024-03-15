namespace Plants.Services.Home
{
	using Data.Models.ApplicationUser;
	using Data.Models.Plant;
	using Models;
	using RepositoryService;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Mvc;

	public class HomeService : IHomeService
	{
		private IRepository _repository;
		private readonly IMapper _mapper;

		public HomeService(IRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PlantHomeViewModel>> GetTrendingPlants()
		{
			var plants = await _repository.AllReadOnly<Plant>()
				.Where(x => x.IsTrending == true)
				.OrderBy(x => x.Id)
				.ToListAsync();

			var model = _mapper.Map<List<PlantHomeViewModel>>(plants);

			return model;
		}

		public async Task<IActionResult> LikeButton(int id, bool isLiked, string userId)
		{
			var plant = await _repository.FindByIdAsync<Plant>(id);
			var user = await _repository.FindByIdAsync<ApplicationUser>(userId);

			if (plant == null || user == null)
			{
				return new NotFoundResult();
			}

			var usersPlants = user.LikedPlants
				.FirstOrDefault(x => x.Id == plant.Id);

			if (isLiked && usersPlants == null)
			{
				user.LikedPlants.Add(plant);
			}
			else
			{
				user.LikedPlants.Remove(plant);
			}

			await _repository.SaveChangesAsync();

			return new OkResult();
		}

	}
}
