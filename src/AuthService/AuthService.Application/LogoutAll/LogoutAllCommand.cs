using MediatR;

namespace AuthService.Application.LogoutAll
{
    public class LogoutAllCommand : IRequest<Unit>
    {
        public required string AccountId { get; set; }
    }
}
