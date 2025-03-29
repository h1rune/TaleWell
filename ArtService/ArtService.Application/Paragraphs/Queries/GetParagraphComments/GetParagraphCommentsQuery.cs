using MediatR;

namespace ArtService.Application.Paragraphs.Queries.GetParagraphComments
{
    public class GetParagraphCommentsQuery : IRequest<ParagraphCommentsVm>
    {
        public Guid ParagraphId { get; set; }
    }
}
