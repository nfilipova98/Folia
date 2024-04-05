namespace Plants.Services.CommentService
{
	using Data.Models.ApplicationUser;
	using Data.Models.Comment;
	using Data.Models.Plant;
	using Models;
	using RepositoryService;
	using ViewModels;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using SendGrid.Helpers.Errors.Model;

	public class CommentService : ICommentService
	{
		private IRepositoryService _repository;
		private readonly IMapper _mapper;

		public CommentService(IRepositoryService repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<CommentsViewModel> GetCommentsAsync(int id)
		{
			var comments = await _repository
				.AllReadOnly<Comment>()
				.Where(x => x.PlantId == id)
				.ToListAsync();

			var plant = await _repository.FindByIdAsync<Plant>(id);

			if (plant == null)
			{
				throw new NotFoundException();
			}

			var model = new CommentsViewModel
			{
				ExistingComments = _mapper.Map<List<CommentViewModel>>(comments)
			};

			model.PlantDescription = plant.Description;
			model.PlantName = plant.Name;

			return model;
		}

		public async Task<CommentViewModel> AddCommentsAsync(CommentViewModel model, string id, int plantId)
		{
			var plant = await _repository.FindByIdAsync<Plant>(plantId);
			var user = await _repository.FindByIdAsync<ApplicationUser>(id);

			if (id != string.Empty && plant != null && user != null)
			{
				model.PlantId = plantId;
				model.ApplicationUserId = id;

				var comment = _mapper.Map<CommentViewModel, Comment>(model);
				comment.ApplicationUser = user;
				comment.Plant = plant;

				await _repository.AddAsync(comment);
				await _repository.SaveChangesAsync();
			}
			else
			{
				throw new ArgumentException();
			}

			return model;
		}
	}
}
