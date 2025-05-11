using MediatR;

namespace AuthService.Application.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<Unit>
    {
        public required string Email { get; set; }
    }
}
