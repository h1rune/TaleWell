using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Queries.GetWorks;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    public class GetWorksDto : IMapWith<GetWorksQuery>
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetWorksDto, GetWorksQuery>()
                .ForMember(query => query.Offset, options => options.MapFrom(dto => dto.Offset))
                .ForMember(query => query.Limit, options => options.MapFrom(dto => dto.Limit));
        }
    }
}
