using ArtService.Domain.Common;

namespace ArtService.Domain
{
    public class Work : IDomainEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }          
        public Guid? OriginalWorkId { get; set; } 
        public Work? OriginalWork { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public ICollection<Review> Reviews { get; set; } = [];
        public ICollection<Volume> Volumes { get; set; } = [];
        public ICollection<Work> Fanfics { get; set; } = [];
    }
}
