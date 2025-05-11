using ArtService.Application.Comments.Commands.CreateComment;
using ArtService.Application.Common.Mappings;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.CommentModels
{
    public class CreateCommentDto : IMapWith<CreateCommentCommand>
    {
        [SwaggerSchema("ID of paragraph for commenting")]
        public Guid ParagraphId { get; set; }

        [SwaggerSchema("Text of comment")]
        public required string Text { get; set; }

        [SwaggerSchema("Notifying about spoiler flag")]
        public bool IsSpoiler { get; set; }

        [SwaggerSchema("ID of chapter, in which spoiler appears for the first time")]
        public Guid? SpoilerChapterId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentDto, CreateCommentCommand>();
        }
    }
}
