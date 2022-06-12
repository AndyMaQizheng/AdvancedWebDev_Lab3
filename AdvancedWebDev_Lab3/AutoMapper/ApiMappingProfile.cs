using AutoMapper;

namespace AdvancedWebDev_Lab3.AutoMapper
{
    public class ApiMappingProfile : Profile
    {
        // AutoMapper implementation to map results from DTO to API objects.
        public ApiMappingProfile()
        {
            CreateMap<DataAccess.Models.Cast, Models.Cast>();
            CreateMap<DataAccess.Models.Director, Models.Director>();
            CreateMap<DataAccess.Models.Genre, Models.Genre>();
            CreateMap<DataAccess.Models.Keyword, Models.Keyword>();
            CreateMap<DataAccess.Models.ProductionCompany, Models.ProductionCompany>();

            CreateMap<DataAccess.Models.Movie, Models.Movie>()
                .ForMember(dest => dest.ShortSummary, opt => opt.MapFrom(src => src.Overview))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.OriginalTitle))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Name)))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Keywords.Select(x => x.Name)))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(x => x.Name)))
                .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Casts.Select(x => x.Name)))
                .ForMember(dest => dest.Productioncompanies, opt => opt.MapFrom(src => src.Productioncompanies.Select(x => x.Name)));
        }
    }
}
