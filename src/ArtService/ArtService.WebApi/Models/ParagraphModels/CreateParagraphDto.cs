using ArtService.Application.Common.Mappings;
using ArtService.Application.Paragraphs.Commands.CreateParagraph;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ParagraphModels
{
    public class CreateParagraphDto : IMapWith<CreateParagraphCommand>
    {
        [SwaggerSchema("ID of paragraph's chapter")]
        public Guid ChapterId { get; set; }

        [SwaggerSchema("Order of new paragraph in chapter")]
        public int Order { get; set; }

        [SwaggerSchema("Text of new paragraph")]
        public required string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateParagraphDto, CreateParagraphCommand>();
        }
    }
}
