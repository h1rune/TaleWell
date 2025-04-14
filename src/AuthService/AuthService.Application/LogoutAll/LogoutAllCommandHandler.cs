using AuthService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Application.LogoutAll
{
    public class LogoutAllCommandHandler(IAuthServiceDbContext dbContext)
        : IRequestHandler<LogoutAllCommand, Unit>
    {
        private readonly IAuthServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(LogoutAllCommand request, CancellationToken cancellationToken)
        {
            var tokens = await _dbContext.RefreshTokens
                .Where(token => token.AccountId == request.AccountId && !token.IsRevoked)
                .ToListAsync(cancellationToken);

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
