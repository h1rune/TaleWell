using MediatR;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
    }
}
