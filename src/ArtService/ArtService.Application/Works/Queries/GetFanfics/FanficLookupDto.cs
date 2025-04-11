using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class FanficLookupDto : IMapWith<Work>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Work, FanficLookupDto>()
                .ForMember(fanficDto => fanficDto.Id, options => options.MapFrom(work => work.Id))
                .ForMember(fanficDto => fanficDto.AuthorId, options => options.MapFrom(work => work.AuthorId))
                .ForMember(fanficDto => fanficDto.Title, options => options.MapFrom(work => work.Title));
        }
    }
}
