using MediatR;

namespace ArtService.Application.Reactions.Queries.GetParagraphReactions
{
    public class GetParagraphReactionsQuery : IRequest<ParagraphReactionsVm>
    {
        public Guid ParagraphId { get; set; }
    }
}
