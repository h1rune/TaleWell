using MediatR;

namespace AuthService.Application.LogoutAll
{
    public class LogoutAllCommand : IRequest<Unit>
    {
        public string AccountId { get; set; } = null!;
    }
}
