using MediatR;

namespace AuthService.Application.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<Unit>
    {
        public required string AccountId { get; set; }
        public required string Token { get; set; }
    }
}
