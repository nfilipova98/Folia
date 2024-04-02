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
		private IRepositoryService _repository;

		public TierResultFilterAttribute(IRepositoryService repository)
		{
			_repository = repository;
		}

		public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			bool isSuccessful = true;

			var user = context.HttpContext.User;
			var userId = user.Id();

			bool isChanged = false;

			if (user.IsInRole("Admin") || !user.Identity.IsAuthenticated || userId == null)
			{
				isSuccessful = false;
			}
			else
			{
				var getUser = await _repository.FindByIdAsync<ApplicationUser>(userId);

				var tierName = getUser?.Tier;
				var tierPoint = getUser?.TierPoints;

				if (getUser != null && tierName != Tier.Blossom)
				{
					var currentPoints = getUser.TierPoints += 5;
					tierPoint = currentPoints;
				}
				if (tierPoint == 25)
				{
					getUser.Tier = Tier.Sprout;
					isChanged = true;
				}
				else if (tierPoint == 50)
				{
					getUser.Tier = Tier.Bloom;
					isChanged = true;
				}
				else if (tierPoint == 75)
				{
					getUser.Tier = Tier.Blossom;
					isChanged = true;
				}
			}

			await next();

			if (isSuccessful)
			{
				await _repository.SaveChangesAsync();
				context.HttpContext.Items["tierUp"] = isChanged;
			}
		}
	}
}
