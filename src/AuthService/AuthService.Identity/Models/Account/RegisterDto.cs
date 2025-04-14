using AuthService.Application.Common.Mappings;
using AuthService.Application.RegisterAccount;
using AutoMapper;

namespace AuthService.WebApi.Models.Account
{
    public class RegisterDto : IMapWith<RegisterAccountCommand>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, RegisterAccountCommand>()
                .ForMember(command => command.Email, options => options.MapFrom(dto => dto.Email))
                .ForMember(command => command.Password, options => options.MapFrom(dto => dto.Password));
        }
    }
}
