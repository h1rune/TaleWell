using MediatR;

namespace ArtService.Application.Chapters.Commands.UpdateChapter
{
    public class UpdateChapterCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

        public int Order { get; set; }
        public string? Title { get; set; }
    }
}
