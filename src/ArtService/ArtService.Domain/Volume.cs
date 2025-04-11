namespace ArtService.Domain
{
    public class Volume
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public string? CoverKey { get; set; }

        public Guid WorkId { get; set; }
        public Work RelatedWork { get; set; } = null!;

        public IList<Chapter>? Chapters { get; set; }
    }
}
