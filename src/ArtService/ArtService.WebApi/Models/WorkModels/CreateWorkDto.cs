using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Commands.CreateWork;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.WorkModels
{
    public class CreateWorkDto : IMapWith<CreateWorkCommand>
    {
        [SwaggerSchema("@Handle of entity's owner.")]
        public required string OwnerHandle { get; set; }

        [SwaggerSchema("Title of new literary work.")]
        public required string Title { get; set; }

        [SwaggerSchema("Description of new literary work.")]
        public string? Description { get; set; }

        [SwaggerSchema("Flag that reflects the fact that this literary work is fanfiction.")]
        public bool IsFanfic { get; set; } = false;

        [SwaggerSchema("Original work's ID, sets only work is a fanfiction.")]
        public Guid? OriginalWorkId { get; set; }

        public ICollection<Guid> TagIds { get; set; } = [];

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWorkDto, CreateWorkCommand>();
        }
    }
}
