using MediatR;

namespace ArtService.Application.Chapters.Queries.GetChapter
{
    public class GetChapterQuery : IRequest<ChapterVm>
    {
        public Guid ChapterId { get; set; }
    }
}
