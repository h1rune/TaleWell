namespace ArtService.Domain
{
    public class Paragraph
    {
        public Guid Id { get; set; }
        public Guid ChapterId { get; set; }
        public int Order { get; set; }
        public required string S3Url { get; set; }
    }
}
