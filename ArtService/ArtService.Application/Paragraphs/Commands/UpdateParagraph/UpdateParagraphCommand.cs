using MediatR;

namespace ArtService.Application.Paragraphs.Commands.UpdateParagraph
{
    public class UpdateParagraphCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Text { get; set; } = null!;
    }
}
