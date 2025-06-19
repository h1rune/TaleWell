using AuthService.Application.Interfaces;
using AuthService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.RegisterAccount
{
    public class RegisterAccountCommandHandler(UserManager<Account> userManager, IEmailService emailService, IMapper mapper)
        : IRequestHandler<RegisterAccountCommand, Unit>
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IEmailService _emailService = emailService;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            var accountEntity = await _userManager.FindByEmailAsync(command.Email);
            if (accountEntity != null && accountEntity.EmailConfirmed)
            {
                throw new UnauthorizedAccessException();
            }
            if (accountEntity == null)
            {
                accountEntity = _mapper.Map<Account>(command);
                await _userManager.CreateAsync(accountEntity, command.Password);
            }
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(accountEntity);
            await _emailService.SendEmailConfirmationAsync(accountEntity.Email!, accountEntity.Id, token, cancellationToken);
            return Unit.Value;
        }
    }
}
