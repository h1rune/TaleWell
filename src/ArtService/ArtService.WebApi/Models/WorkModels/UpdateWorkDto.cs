using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Commands.UpdateWork;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.WorkModels
{
    public class UpdateWorkDto : IMapWith<UpdateWorkCommand>
    {
        [SwaggerSchema("New title of literary work.")]
        public required string Title { get; set; } 

        [SwaggerSchema("New description of literary work.")]
        public string? Description { get; set; }

        [SwaggerSchema("Flag that reflects the fact that this literary work is fanfiction.")]
        public bool IsFanfic { get; set; }

        [SwaggerSchema("Original work's ID, sets only work is a fanfiction.")]
        public Guid? OriginalWorkId { get; set; }
    }
}
