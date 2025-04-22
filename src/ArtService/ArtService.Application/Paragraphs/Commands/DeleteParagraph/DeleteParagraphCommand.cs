using MediatR;

namespace ArtService.Application.Paragraphs.Commands.DeleteParagraph
{
    public class DeleteParagraphCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ParagraphId { get; set; }
    }
}
