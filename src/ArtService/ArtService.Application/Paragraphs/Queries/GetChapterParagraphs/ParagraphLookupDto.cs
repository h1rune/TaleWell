namespace ArtService.Application.Paragraphs.Queries.GetChapterParagraphs
{
    public class ParagraphLookupDto
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public required string Text { get; set; } 
    }
}
