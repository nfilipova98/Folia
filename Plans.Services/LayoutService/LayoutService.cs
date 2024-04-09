namespace Plants.Services.LayoutService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Services.RepositoryService;

	using Microsoft.EntityFrameworkCore;

	public class LayoutService : ILayoutService
	{
		private IRepositoryService _repository;

		public LayoutService(IRepositoryService repository)
		{
			_repository = repository;
		}

		public async Task<Tier?> FindUsersTierByIdAsync(string userId)
		{
			var user = await _repository.FindByIdAsync<ApplicationUser>(userId);

			return user?.Tier;
		}

		public async Task<string?> FindUsersPictureByIdAsync(string userId)
		{
			var user = await _repository
				.AllReadOnly<ApplicationUser>()
				.Include(x => x.UserConfiguration)
				.FirstOrDefaultAsync(x => x.Id == userId);

			return user?.UserConfiguration?.UserPictureUrl ?? null;
		}
	}
}
