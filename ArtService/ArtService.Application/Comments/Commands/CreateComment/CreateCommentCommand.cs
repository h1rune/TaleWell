using MediatR;

namespace ArtService.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public string Text { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public int? SpoilerChapterNumber { get; set; }
    }
}
