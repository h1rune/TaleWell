using AuthService.Domain;
using MediatR;

namespace AuthService.Application.Login
{
    public class LoginCommand : IRequest<TokensDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
