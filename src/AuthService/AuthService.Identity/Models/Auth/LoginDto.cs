using AuthService.Application.Common.Mappings;
using AuthService.Application.Login;
using AutoMapper;

namespace AuthService.WebApi.Models.Auth
{
    public class LoginDto : IMapWith<LoginCommand>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginCommand>()
                .ForMember(command => command.Email, options => options.MapFrom(dto => dto.Email))
                .ForMember(command => command.Password, options => options.MapFrom(dto => dto.Password));
        }
    }
}
