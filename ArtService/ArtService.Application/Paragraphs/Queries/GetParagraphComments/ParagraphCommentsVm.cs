namespace ArtService.Application.Paragraphs.Queries.GetParagraphComments
{
    public class ParagraphCommentsVm
    {
        public IList<CommentLookupDto> Comments { get; set; } = null!;
    }
}
