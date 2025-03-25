using ArtService.Domain;

namespace ArtService.Application.Reactions.Queries.GetParagraphReactions
{
    public class ParagraphReactionsVm
    {
        public required Dictionary<ReactionType, int> Reactions { get; set; }
    }
}
