using MediatR;

namespace ArtService.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
    }
}
