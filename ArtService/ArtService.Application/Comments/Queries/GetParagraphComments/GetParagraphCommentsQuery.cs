using MediatR;

namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class GetParagraphCommentsQuery : IRequest<ParagraphCommentsVm>
    {
        public Guid ParagraphId { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 5;
    }
}
