using MediatR;

namespace AuthService.Application.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Unit>
    {
        public required string AccountId { get; set; }
        public required string Token { get; set; }
        public required string NewPassword { get; set; }
    }
}
