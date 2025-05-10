using ArtService.Domain.Common;

namespace ArtService.Domain
{
    public class Paragraph : IDomainEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ChapterId { get; set; }
        public Chapter RelatedChapter { get; set; } = null!;

        public int Order { get; set; }
        public required string S3Key { get; set; }

        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<Reaction> Reactions { get; set; } = [];
    }
}
