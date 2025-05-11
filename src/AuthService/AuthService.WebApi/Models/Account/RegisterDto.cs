using AuthService.Application.Common.Mappings;
using AuthService.Application.RegisterAccount;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthService.WebApi.Models.Account
{
    public class RegisterDto : IMapWith<RegisterAccountCommand>
    {
        [SwaggerSchema("Account Email")]
        public required string Email { get; set; }

        [SwaggerSchema("Account password")]
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, RegisterAccountCommand>();
        }
    }
}
