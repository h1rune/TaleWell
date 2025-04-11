using MediatR;

namespace ArtService.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid WorkId { get; set; }
    }
}
