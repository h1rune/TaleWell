using AuthService.Application.Common.Mappings;
using AuthService.Application.TokenRefresh;
using AutoMapper;

namespace AuthService.WebApi.Models.Session
{
    public class RefreshTokenDto : IMapWith<RefreshTokenCommand>
    {
        public string RefreshToken { get; set; } = null!;
        public string AccountId { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RefreshTokenDto, RefreshTokenCommand>()
                .ForMember(command => command.RefreshToken, options => options.MapFrom(dto => dto.RefreshToken))
                .ForMember(command => command.AccountId, options => options.MapFrom(dto => dto.AccountId));
        }
    }
}
