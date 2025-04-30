using MediatR;

namespace AuthService.Application.RegisterAccount
{
    public class RegisterAccountCommand : IRequest<string>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
