using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Queries.GetFanfics;
using AutoMapper;

namespace ArtService.WebApi.Models.WorkModels
{
    public class GetFanficsDto : IMapWith<GetFanficsQuery>
    {
        public Guid OriginalId { get; set; }
        public int? Offset { get; set; } = 0;
        public int? Limit { get; set; } = 5;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetFanficsDto, GetFanficsQuery>()
                .ForMember(query => query.OriginalId, options => options.MapFrom(dto => dto.OriginalId))
                .ForMember(query => query.Offset, options => options.MapFrom(dto => dto.Offset))
                .ForMember(query => query.Limit, options => options.MapFrom(dto => dto.Limit));
        }
    }
}
