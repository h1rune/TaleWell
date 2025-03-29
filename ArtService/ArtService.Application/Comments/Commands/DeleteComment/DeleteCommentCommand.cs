using MediatR;

namespace ArtService.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
