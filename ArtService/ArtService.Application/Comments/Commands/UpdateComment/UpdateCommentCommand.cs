using MediatR;

namespace ArtService.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Text { get; set; }
    }
}
