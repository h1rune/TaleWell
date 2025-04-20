using AuthService.Domain;
using AuthService.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Infrastructure
{
    public class TokenService(IConfiguration config, UserManager<Account> userManager, IAuthServiceDbContext dbContext) 
        : ITokenService
    {
        private readonly IConfiguration _config = config;
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IAuthServiceDbContext _dbContext = dbContext;

        public async Task<TokenDto> GenerateTokensAsync(Account account, CancellationToken cancellationToken)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id),
                new Claim(ClaimTypes.Name, account.Email!),
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

            return new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = refreshTokenValue,
                ExpiresAt = expiry
            };
        }

        public async Task<TokenDto> RefreshTokenAsync(string refreshTokenValue, string accountId, CancellationToken cancellationToken)
        {
            var token = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(refresh => refresh.Token == refreshTokenValue 
                    && refresh.AccountId == accountId, cancellationToken);

            if (token == null || token.ExpiresAt < DateTime.UtcNow || token.IsRevoked)
                throw new UnauthorizedAccessException("Invalid or expired refresh token.");

            token.IsRevoked = true;
            _dbContext.RefreshTokens.Update(token);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var account = await _userManager.FindByIdAsync(accountId);
            return account == null
                ? throw new UnauthorizedAccessException("User not found.")
                : await GenerateTokensAsync(account, cancellationToken);
        }
    }
}
