using MediatR;

namespace ArtService.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public required string Text { get; set; }
    }
}
