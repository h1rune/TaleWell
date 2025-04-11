using MediatR;

namespace ArtService.Application.Paragraphs.Queries.GetParagraph
{
    public class GetParagraphQuery : IRequest<ParagraphVm>
    {
        public Guid ParagraphId { get; set; }
    }
}
