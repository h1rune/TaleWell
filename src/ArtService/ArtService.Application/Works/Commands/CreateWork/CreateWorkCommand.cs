using MediatR;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
    }
}
