namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class ParagraphCommentsVm
    {
        public required IList<CommentLookupDto> Comments { get; set; }
    }
}
