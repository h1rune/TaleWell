using AuthService.Application.Interfaces;
using AuthService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.RegisterAccount
{
    public class RegisterAccountCommandHandler(UserManager<Account> userManager, IEmailService emailService, IMapper mapper)
        : IRequestHandler<RegisterAccountCommand, string>
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IEmailService _emailService = emailService;
        private readonly IMapper _mapper = mapper;

        public async Task<string> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(command);
            await _userManager.CreateAsync(account, command.Password);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(account);
            await _emailService.SendEmailConfirmationAsync(account.Email!, account.Id, token, cancellationToken);

            return account.Id;
        }
    }
}
