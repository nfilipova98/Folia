namespace Plants.Services.Mapping
{
	using Data.Models.Comment;
	using Data.Models.Pet;
	using Data.Models.Plant;
	using Models;
	using ViewModels;

	using AutoMapper;
	using Plants.Data.Models.ApplicationUser;

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
			CreateMap<Plant, PlantEditOrAddViewModel>().ReverseMap();

			CreateMap<Pet, PetViewModel>().ReverseMap();
			CreateMap<PetAddViewModel, Pet>().ReverseMap();

			CreateMap<CommentModel, Comment>();
			CreateMap<Comment, CommentViewModel>()
				.ForMember(x => x.ApplicationUserName, x => x.MapFrom(x => x.ApplicationUser.UserName))
				.ForMember(x => x.ApplicationUserPictureUrl, x => x.MapFrom(x => x.ApplicationUser.UserConfiguration.UserPictureUrl ?? null));

			CreateMap<RegionAddViewModel, Region>().ReverseMap();
			CreateMap<RegionViewModel, Region>().ReverseMap();

			CreateMap<FirstLoginViewModel, UserConfiguration>();
		}
	}
}
