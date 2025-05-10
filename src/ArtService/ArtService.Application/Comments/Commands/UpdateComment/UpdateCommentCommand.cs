using MediatR;

namespace ArtService.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public required string Text { get; set; }
        public bool IsSpoiler { get; set; }
        public Guid? SpoilerChapterId { get; set; }
    }
}
