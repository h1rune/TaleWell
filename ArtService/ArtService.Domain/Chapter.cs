namespace ArtService.Domain
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
    }
}
