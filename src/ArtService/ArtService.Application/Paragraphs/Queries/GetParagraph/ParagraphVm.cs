namespace ArtService.Application.Paragraphs.Queries.GetParagraph
{
    public class ParagraphVm
    {
        public Guid ChapterId { get; set; }
        public int Order { get; set; }
        public string Text { get; set; } = null!;
    }
}
