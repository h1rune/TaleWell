using AuthService.Application.Common.Mappings;
using AuthService.Domain;
using AutoMapper;
using MediatR;

namespace AuthService.Application.RegisterAccount
{
    public class RegisterAccountCommand : IRequest<Unit>, IMapWith<Account>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterAccountCommand, Account>()
                .ForMember(account => account.Email, options => options.MapFrom(command => command.Email))
                .ForMember(account => account.UserName, options => options.MapFrom(command => command.Email));
        }
    }
}
