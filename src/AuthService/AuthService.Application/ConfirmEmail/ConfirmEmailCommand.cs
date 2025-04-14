using MediatR;

namespace AuthService.Application.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<Unit>
    {
        public string AccountId { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
