using AuthService.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.DeleteAccount
{
    public class DeleteAccountCommandHandler(UserManager<Account> userManager)
        : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly UserManager<Account> _userManager = userManager;

        public Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
