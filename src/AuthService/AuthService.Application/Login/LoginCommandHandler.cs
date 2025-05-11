using AuthService.Application.Common.Exceptions;
using AuthService.Application.Interfaces;
using AuthService.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Login
{
    public class LoginCommandHandler(SignInManager<Account> signInManager, UserManager<Account> userManager, ITokenService tokenService)
        : IRequestHandler<LoginCommand, TokensDto>
    {
        private readonly SignInManager<Account> _signInManager = signInManager;
        private readonly UserManager<Account> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<TokensDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByEmailAsync(command.Email)
                ?? throw new NotFoundException(nameof(Account), command.Email);
            if (!await _userManager.IsEmailConfirmedAsync(account))
                throw new UnauthorizedAccessException("Unconfirmed email.");

            var result = await _signInManager.CheckPasswordSignInAsync(account, command.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid credentials.");

            return await _tokenService.GenerateTokensAsync(account, cancellationToken);
        }
    }
}
