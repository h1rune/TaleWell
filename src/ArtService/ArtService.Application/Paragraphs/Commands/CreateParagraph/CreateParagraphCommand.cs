using MediatR;

namespace ArtService.Application.Paragraphs.Commands.CreateParagraph
{
    public class CreateParagraphCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ChapterId { get; set; }
        public int Order { get; set; }
        public required string Text { get; set; }
    }
}
