using ArtService.Application.Comments.Commands.CreateComment;
using ArtService.Application.Common.Mappings;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.CommentModels
{
    public class CreateCommentDto : IMapWith<CreateCommentCommand>
    {
        [SwaggerSchema("ID of paragraph for commenting")]
        public Guid ParagraphId { get; set; }

        [SwaggerSchema("Text of comment")]
        public string Text { get; set; } = null!;

        [SwaggerSchema("Notifying about spoiler flag")]
        public bool IsSpoiler { get; set; }

        [SwaggerSchema("Number of chapter, in which spoiler appears for the first time")]
        public int? SpoilerChapterNumber { get; set; }
    }
}
