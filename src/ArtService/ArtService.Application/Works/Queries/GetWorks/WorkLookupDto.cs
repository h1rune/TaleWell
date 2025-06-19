using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Works.Queries.GetWorks
{
    public class WorkLookupDto : IMapWith<Work>
    {
        public Guid Id { get; set; }
        public required string OwnerHandle { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<LiteraryTag> Tags { get; set; } = [];
        public required LiteraryArchetype LiteraryArchetype { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Work, WorkLookupDto>();
        }
    }
}
