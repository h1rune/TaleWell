﻿using AuthService.Application.Interfaces;
using AuthService.Domain;
using MediatR;

namespace AuthService.Application.TokenRefresh
{
    public class RefreshTokenCommandHandler(ITokenService tokenService)
        : IRequestHandler<RefreshTokenCommand, TokensDto>
    {
        private readonly ITokenService _tokenService = tokenService;

        public async Task<TokensDto> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            return await _tokenService
                .RefreshTokenAsync(command.RefreshToken, cancellationToken);
        }
    }
}
