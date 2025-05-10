using ArtService.Domain.Common;

namespace ArtService.Domain
{
    public class Reaction : IDomainEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ParagraphId { get; set; }
        public Paragraph RelatedParagraph { get; set; } = null!;

        public ReactionType Type { get; set; }
        public DateTime PutAt { get; set; }
    }
}
