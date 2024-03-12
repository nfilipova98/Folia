namespace Plants.Utilities
{
	using Data.Models.ApplicationUser;
	using Data.Models.Enums;
	using Services.RepositoryService;

	using Microsoft.AspNetCore.Mvc.Filters;
	using System.Threading.Tasks;
	using System.Security.Claims;

	public class TierResultFilterAttribute : ResultFilterAttribute
	{
		private IRepository _repository;

		public TierResultFilterAttribute(IRepository repository)
		{
			_repository = repository;
		}

		public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			bool isSuccessful = true;

			var user = context.HttpContext.User;
			var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

			if (user.IsInRole("Admin") || !user.Identity.IsAuthenticated || userId == null)
			{
				isSuccessful = false;
			}
			else
			{
				var getUser = await _repository
					.FindByIdAsync<ApplicationUser>(userId);

				var tierName = getUser?.Tier;
				var tierPoint = getUser?.TierPoints;

				if (getUser != null && tierName != Tier.Blossom)
				{
					tierPoint += 10;
				}
				if (tierPoint > 25)
				{
					tierName = Tier.Sprout;
				}
				else if (tierPoint > 50)
				{
					tierName = Tier.Bloom;
				}
				else if (tierPoint > 75)
				{
					tierName = Tier.Blossom;
				}
			}

			await next();

			if (isSuccessful)
			{
				await _repository.SaveChangesAsync();
			}
		}
	}
}
