using ArtService.Domain.Common;

namespace ArtService.Domain
{
    public class Review : IDomainEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }

        public Guid WorkId { get; set; }
        public Work ReviewedWork { get; set; } = null!;

        public ReactionType Mark { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
