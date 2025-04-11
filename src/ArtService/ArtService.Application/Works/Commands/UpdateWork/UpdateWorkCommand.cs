using ArtService.Application.Interfaces;
using MediatR;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommand : IRequest<Unit>, IHasOriginalWorkId
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
    }
}
