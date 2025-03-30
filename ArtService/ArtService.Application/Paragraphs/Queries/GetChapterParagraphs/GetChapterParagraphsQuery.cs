using MediatR;

namespace ArtService.Application.Paragraphs.Queries.GetChapterParagraphs
{
    public class GetChapterParagraphsQuery : IRequest<ChapterParagraphsVm>
    {
        public Guid ChapterId { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
