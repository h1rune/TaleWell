using MediatR;

namespace ArtService.Application.Paragraphs.Commands.DeleteParagraph
{
    public class DeleteParagraphCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
