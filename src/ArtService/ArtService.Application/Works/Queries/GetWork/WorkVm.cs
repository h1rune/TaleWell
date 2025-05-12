using ArtService.Application.Common.Mappings;
using ArtService.Domain;
using AutoMapper;

namespace ArtService.Application.Works.Queries.GetWork
{
    public class WorkVm : IMapWith<Work>
    {
        public Guid OwnerId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<LiteraryTag> Tags { get; set; } = [];
        public required LiteraryArchetype LiteraryArchetype { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Work, WorkVm>();
        }
    }
}
