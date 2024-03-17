namespace Plants.Services.Mapping
{
	using Data.Models.Comment;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using Models;

	using AutoMapper;

	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Plant, PlantHomeViewModel>();
			CreateMap<Plant, PlantAllViewModel>();
			CreateMap<Plant, PlantDeleteViewModel>();
			CreateMap<Plant, PlantEditOrAddViewModel>();
			CreateMap<PlantEditOrAddViewModel, Plant>();

			CreateMap<Pet, PetViewModel>();

			CreateMap<Comment, CommentViewModel>();
		}
	}
}
