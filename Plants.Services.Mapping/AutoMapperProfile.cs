namespace Plants.Services.Mapping
{
    using Data.Models.Plant;
    using Models;

    using AutoMapper;
    using Plants.Services.Data.AdminService.Models;

    public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Plant, PlantModel>();
		}
	}
}
