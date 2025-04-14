using AuthService.Domain;
using MediatR;

namespace AuthService.Application.Login
{
    public class LoginCommand : IRequest<TokenDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
