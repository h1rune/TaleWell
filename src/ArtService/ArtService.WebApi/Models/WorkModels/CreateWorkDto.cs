using ArtService.Application.Common.Mappings;
using ArtService.Application.Works.Commands.CreateWork;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.WorkModels
{
    public class CreateWorkDto : IMapWith<CreateWorkCommand>
    {
        [SwaggerSchema("Title of new literary work.")]
        public required string Title { get; set; }

        [SwaggerSchema("Description of new literary work.")]
        public string? Description { get; set; }

        [SwaggerSchema("Flag that reflects the fact that this literary work is fanfiction.")]
        public bool IsFanfic { get; set; }

        [SwaggerSchema("Original work's ID, sets only work is a fanfiction.")]
        public Guid? OriginalWorkId { get; set; }
    }
}
