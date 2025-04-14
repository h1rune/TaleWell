using AuthService.Application.Interfaces;
using AuthService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.RegisterUser
{
    public class RegisterUserCommandHandler(UserManager<Account> userManager, IEmailService emailService, IMapper mapper)
        : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly UserManager<Account> _userManager = userManager;
        private readonly IEmailService _emailService = emailService;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(command);
            var result = await _userManager.CreateAsync(account, command.Password);

            if (!result.Succeeded)
                throw new Exception("User creation failed");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(account);
            await _emailService.SendEmailConfirmationAsync(account.Email!, account.Id, token, cancellationToken);

            return Unit.Value;
        }
    }
}
