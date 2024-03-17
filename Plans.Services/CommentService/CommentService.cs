namespace Plants.Services.CommentService
{
	using Data.Models.Comment;
	using Models;
	using RepositoryService;

	using AutoMapper;
	using Microsoft.EntityFrameworkCore;

	public class CommentService : ICommentService
	{
		private IRepository _repository;
		private readonly IMapper _mapper;

		public CommentService(IRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CommentViewModel>> GetCommentsAsync()
		{
			var coments = await _repository
				.AllReadOnly<Comment>()
				.ToListAsync();

			var model = _mapper.Map<IEnumerable<CommentViewModel>>(coments);

			return model;
		}
	}
}
