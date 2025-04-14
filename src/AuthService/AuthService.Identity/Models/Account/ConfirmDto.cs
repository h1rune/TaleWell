using AuthService.Application.Common.Mappings;
using AuthService.Application.ConfirmEmail;
using AutoMapper;

namespace AuthService.WebApi.Models.Account
{
    public class ConfirmDto : IMapWith<ConfirmEmailCommand>
    {
        public string AccountId { get; set; } = null!;
        public string Token { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConfirmDto, ConfirmEmailCommand>()
                .ForMember(command => command.AccountId, options => options.MapFrom(dto => dto.AccountId))
                .ForMember(command => command.Token, options => options.MapFrom(dto => dto.Token));
        }
    }
}
