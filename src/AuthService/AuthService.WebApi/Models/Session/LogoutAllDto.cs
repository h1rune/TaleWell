using AuthService.Application.Common.Mappings;
using AuthService.Application.LogoutAll;
using AutoMapper;

namespace AuthService.WebApi.Models.Session
{
    /// <summary>
    /// Запрос на выход из всех сессий.
    /// </summary>
    public class LogoutAllDto : IMapWith<LogoutAllCommand>
    {
        /// <summary>
        /// Уникальный идентификатор аккаунта.
        /// </summary>
        /// <example>f3a4d7bc-9c9e-4f44-a2d3-fb9d5c112233</example>
        public required string AccountId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LogoutAllDto, LogoutAllCommand>()
                .ForMember(command => command.AccountId, options => options.MapFrom(dto => dto.AccountId));
        }
    }
}
