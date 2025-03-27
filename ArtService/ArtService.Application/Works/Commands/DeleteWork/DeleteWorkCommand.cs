using MediatR;

namespace ArtService.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
