using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Works.Queries.GetFanfics
{
    public class FanficLookupDto : IMapWith<Work>
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public required string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Work, FanficLookupDto>();
        }
    }
}
