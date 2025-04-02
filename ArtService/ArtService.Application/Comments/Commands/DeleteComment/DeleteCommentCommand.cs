using MediatR;

namespace ArtService.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
