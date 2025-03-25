namespace ArtService.Domain
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Work RelatedWork { get; set; } = null!;

        public uint Order { get; set; }
        public string? Title { get; set; }

        public ICollection<Paragraph>? Paragraphs { get; set; }
    }
}
