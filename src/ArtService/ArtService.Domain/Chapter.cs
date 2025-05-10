using ArtService.Domain.Common;

namespace ArtService.Domain
{
    public class Chapter : IDomainEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid VolumeId { get; set; }
        public Volume RelatedVolume { get; set; } = null!;

        public int Order { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Paragraph> Paragraphs { get; set; } = [];
    }
}
