using MediatR;

namespace ArtService.Application.Chapters.Commands.CreateChapter
{
    public class CreateChapterCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid VolumeId { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
    }
}
