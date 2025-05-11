using AuthService.Application.Common.Mappings;
using AuthService.Application.ConfirmEmail;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthService.WebApi.Models.Account
{
    public class ConfirmDto : IMapWith<ConfirmEmailCommand>
    {
        [SwaggerSchema("Account ID for email confirmation")] 
        public required string AccountId { get; set; }

        [SwaggerSchema("Email confirmation token")]
        public required string Token { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConfirmDto, ConfirmEmailCommand>();
        }
    }
}
