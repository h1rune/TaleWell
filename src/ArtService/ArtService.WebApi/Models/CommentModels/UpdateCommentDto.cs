using ArtService.Application.Comments.Commands.UpdateComment;
using ArtService.Application.Common.Mappings;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.CommentModels
{
    public class UpdateCommentDto : IMapWith<UpdateCommentCommand>
    {
        [SwaggerSchema("Text of comment")]
        public string Text { get; set; } = null!;

        [SwaggerSchema("Notifying about spoiler flag")]
        public bool IsSpoiler { get; set; }

        [SwaggerSchema("ID of chapter, in which spoiler appears for the first time")]
        public Guid? SpoilerChapterId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentDto, UpdateCommentCommand>();
        }
    }
}
