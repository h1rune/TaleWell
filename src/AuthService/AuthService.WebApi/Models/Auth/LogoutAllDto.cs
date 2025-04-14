using AuthService.Application.Common.Mappings;
using AuthService.Application.LogoutAll;
using AutoMapper;

namespace AuthService.WebApi.Models.Auth
{
    public class LogoutAllDto : IMapWith<LogoutAllCommand>
    {
        public string AccountId { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LogoutAllDto, LogoutAllCommand>()
                .ForMember(command => command.AccountId, options => options.MapFrom(dto => dto.AccountId));
        }
    }
}
