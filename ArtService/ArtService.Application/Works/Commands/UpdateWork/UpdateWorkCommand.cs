using MediatR;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
    }
}
