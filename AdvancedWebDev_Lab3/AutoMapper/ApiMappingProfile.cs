using AutoMapper;

namespace AdvancedWebDev_Lab3.AutoMapper
{
    public class ApiMappingProfile : Profile
    {
        /*
        public ApiMappingProfile()
        {
            CreateMap<DataAccess.Models.Movie, Models.Movie>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Name)))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Keywords.Select(x => x.Name)))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(x => x.Name)))
                .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast.Select(x => x.Name)))
                .ForMember(dest => dest.Productioncompanies, opt => opt.MapFrom(src => src.Productioncompanies.Select(x => x.Name)));
        }
        */
    }
}
