////namespace Plants.Services.AllService
////{
////	using RepositoryService;

////	using AutoMapper;

////	public class AllService : IAllService
////	{
////		private readonly IRepository _repository;
////		private readonly IMapper _mapper;

////		public AllService(IRepository repository, IMapper mapper)
////		{
////			_repository = repository;
////			_mapper = mapper;
////		}

////		public async Task<IEnumerable<T>> GetAllAsync<T>()
////		{
////			var entity = await _repository.AllReadOnly<T>()
////				.ToListAsync();

////			var model = _mapper.Map<List<T>>(entity);

////			return model;
////		}
////	}
////}
