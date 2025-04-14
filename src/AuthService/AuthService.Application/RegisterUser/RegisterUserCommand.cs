using AuthService.Application.Common.Mappings;
using AuthService.Domain;
using AutoMapper;
using MediatR;

namespace AuthService.Application.RegisterUser
{
    public class RegisterUserCommand : IRequest<Unit>, IMapWith<Account>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterUserCommand, Account>()
                .ForMember(account => account.Email, options => options.MapFrom(command => command.Email));
        }
    }
}
