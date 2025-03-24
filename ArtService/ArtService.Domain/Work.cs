namespace ArtService.Domain
{
    public class Work
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }          
        public Guid? OriginalWorkId { get; set; } 
        public Work? OriginalWork { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Chapter>? Chapters { get; set; }
        public ICollection<Work>? Fanfics { get; set; }
    }
}
