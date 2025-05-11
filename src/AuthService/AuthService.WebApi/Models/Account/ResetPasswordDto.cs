using AuthService.Application.Common.Mappings;
using AuthService.Application.ResetPassword;
using AutoMapper;

namespace AuthService.WebApi.Models.Account
{
    public class ResetPasswordDto : IMapWith<ResetPasswordCommand>
    {
        public required string AccountId { get; set; }
        public required string Token { get; set; }
        public required string NewPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ResetPasswordDto, ResetPasswordCommand>();
        }
    }
}
