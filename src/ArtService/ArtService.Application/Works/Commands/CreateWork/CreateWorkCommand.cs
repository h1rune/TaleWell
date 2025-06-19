using ArtService.Domain.Common;
using MediatR;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public required string OwnerHandle { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public FormType FormType { get; set; }

        public bool IsFanfic { get; set; }
        public Guid? OriginalWorkId { get; set; }

        public ICollection<Guid> TagIds { get; set; } = [];
    }
}
