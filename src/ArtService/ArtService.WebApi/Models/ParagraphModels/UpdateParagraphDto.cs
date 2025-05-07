using ArtService.Application.Common.Mappings;
using ArtService.Application.Paragraphs.Commands.UpdateParagraph;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ParagraphModels
{
    public class UpdateParagraphDto : IMapWith<UpdateParagraphCommand>
    {
        [SwaggerSchema("New order of paragraph")]
        public int Order { get; set; }

        [SwaggerSchema("New text of paragraph")]
        public required string Text { get; set; }
    }
}
