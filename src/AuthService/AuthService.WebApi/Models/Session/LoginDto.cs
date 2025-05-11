using AuthService.Application.Common.Mappings;
using AuthService.Application.Login;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthService.WebApi.Models.Session
{
    public class LoginDto : IMapWith<LoginCommand>
    {
        [SwaggerSchema("Account email")]
        public required string Email { get; set; }

        [SwaggerSchema("Account password")]
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginCommand>();
        }
    }
}
