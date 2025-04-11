using ArtService.Application.Interfaces;
using MediatR;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommand : IRequest<Guid>, IHasOriginalWorkId
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }
    }
}
