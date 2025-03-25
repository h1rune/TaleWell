using MediatR;

namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class GetParagraphCommentsQuery : IRequest<ParagraphCommentsVm>
    {
        public Guid ParagraphId { get; set; }
    }
}
