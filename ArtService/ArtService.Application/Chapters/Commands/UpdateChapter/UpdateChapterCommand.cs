using MediatR;

namespace ArtService.Application.Chapters.Commands.UpdateChapter
{
    public class UpdateChapterCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ChapterId { get; set; }

        public int Order { get; set; }
        public string? Title { get; set; }
    }
}
