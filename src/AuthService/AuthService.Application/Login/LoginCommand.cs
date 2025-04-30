using AuthService.Domain;
using MediatR;

namespace AuthService.Application.Login
{
    public class LoginCommand : IRequest<TokensDto>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
