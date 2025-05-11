using AuthService.Domain;
using AuthService.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Application.Common.Exceptions;

namespace AuthService.Infrastructure
{
    public class TokenService(IConfiguration config, UserManager<Account> userManager, IAuthServiceDbContext dbContext) 
        : ITokenService
    {
        private readonly IConfiguration _config = config;
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IAuthServiceDbContext _dbContext = dbContext;

        public async Task<TokensDto> GenerateTokensAsync(Account account, CancellationToken cancellationToken)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id),
                new Claim(JwtRegisteredClaimNames.Email, account.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddMinutes(60);

            var accessToken = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            var refreshTokenValue = Guid.NewGuid().ToString();
            var refreshToken = new RefreshToken
            {
                Token = refreshTokenValue,
                AccountId = account.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            await _dbContext.RefreshTokens.AddAsync(refreshToken, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TokensDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = refreshTokenValue,
                AccessExpiresAt = expiry,
                RefreshExpiresAt = refreshToken.ExpiresAt
            };
        }

        public async Task<TokensDto> RefreshTokenAsync(string refreshTokenValue, CancellationToken cancellationToken)
        {
            var token = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(refresh => refresh.Token == refreshTokenValue, cancellationToken)
                ?? throw new NotFoundException(nameof(RefreshToken), refreshTokenValue);

            if (token.ExpiresAt < DateTime.UtcNow || token.IsRevoked)
                throw new UnauthorizedAccessException("Invalid or expired refresh token.");

            token.IsRevoked = true;
            _dbContext.RefreshTokens.Update(token);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var account = await _userManager.FindByIdAsync(token.AccountId)
                ?? throw new NotFoundException(nameof(Account), token.AccountId);

            return await GenerateTokensAsync(account, cancellationToken);
        }
    }
}
