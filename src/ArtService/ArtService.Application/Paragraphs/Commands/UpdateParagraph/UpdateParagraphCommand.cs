using MediatR;

namespace ArtService.Application.Paragraphs.Commands.UpdateParagraph
{
    public class UpdateParagraphCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
        public int Order { get; set; }
        public string Text { get; set; } = null!;
    }
}
