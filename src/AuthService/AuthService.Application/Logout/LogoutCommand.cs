using MediatR;

namespace AuthService.Application.Logout
{
    public class LogoutCommand : IRequest<Unit>
    {
        public required string RefreshToken { get; set; }
    }
}
