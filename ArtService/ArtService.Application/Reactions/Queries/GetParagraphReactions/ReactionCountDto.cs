using ArtService.Application.Common.Mappings;
using ArtService.Domain;

namespace ArtService.Application.Reactions.Queries.GetParagraphReactions
{
    public class ReactionCountDto
    {
        public ReactionType Type { get; set; }
        public int Count { get; set; }
    }
}
