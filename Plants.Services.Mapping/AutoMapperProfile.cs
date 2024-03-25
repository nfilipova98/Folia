namespace Plants.Services.Mapping
{
	using Data.Models.Comment;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using Models;
	using ViewModels;

	using AutoMapper;

	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Plant, PlantHomeViewModel>()
				 .ForMember(dest => dest.IsLiked, opt => opt.MapFrom((src, dest, destMember, context) =>
				 {
					 var userId = context.Items["userId"];
					 if (userId != null)
					 {
						 return src.UsersLikedPlant.Any(x => x.Id.Equals(userId));
					 }

					 return false;
				 }));
			CreateMap<Plant, PlantAllViewModel>()
				 .ForMember(dest => dest.IsLiked, opt => opt.MapFrom((src, dest, destMember, context) =>
				 {
					 var userId = context.Items["userId"];
					 if (userId != null)
					 {
						 return src.UsersLikedPlant.Any(x => x.Id.Equals(userId));
					 }

					 return false;
				 }));
			CreateMap<Plant, PlantDeleteViewModel>();
			CreateMap<Plant, PlantEditOrAddViewModel>();
			CreateMap<PlantEditOrAddViewModel, Plant>();

			CreateMap<Pet, PetViewModel>();
			CreateMap<PetViewModel, Pet>();
			CreateMap<PetAddViewModel, Pet>();
			CreateMap<Pet, PetAddViewModel>();

			CreateMap<Comment, CommentViewModel>();
		}
	}
}
