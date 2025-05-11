using AuthService.Application.Common.Exceptions;
using AuthService.Application.Interfaces;
using AuthService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Application.Logout
{
    public class LogoutCommandHandler(IAuthServiceDbContext dbContext)
        : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly IAuthServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var token = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(token => token.Token == request.RefreshToken 
                    && !token.IsRevoked, cancellationToken)
                ?? throw new NotFoundException(nameof(RefreshToken), request.RefreshToken);

            token.IsRevoked = true;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
