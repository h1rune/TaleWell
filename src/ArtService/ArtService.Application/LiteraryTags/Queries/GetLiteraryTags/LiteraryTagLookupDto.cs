using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.LiteraryTags.Queries.GetLiteraryTags
{
    public class LiteraryTagLookupDto : IMapWith<LiteraryTag>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LiteraryTag, LiteraryTagLookupDto>();
        }
    }
}
