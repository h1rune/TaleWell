using AuthService.Application.Common.Mappings;
using AuthService.Application.ConfirmEmail;
using AutoMapper;

namespace AuthService.WebApi.Models.Account
{
    /// <summary>
    /// Параметры подтверждения email после регистрации.
    /// </summary>
    public class ConfirmDto : IMapWith<ConfirmEmailCommand>
    {
        /// <summary>
        /// Уникальный идентификатор аккаунта.
        /// </summary>
        /// <example>3f4e6a23-01fc-4e5a-91fa-2c1d9b5e1234</example>
        public string AccountId { get; set; } = null!;

        /// <summary>
        /// Токен подтверждения, отправленный на email.
        /// </summary>
        /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...</example>
        public string Token { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConfirmDto, ConfirmEmailCommand>()
                .ForMember(command => command.AccountId, options => options.MapFrom(dto => dto.AccountId))
                .ForMember(command => command.Token, options => options.MapFrom(dto => dto.Token));
        }
    }
}
