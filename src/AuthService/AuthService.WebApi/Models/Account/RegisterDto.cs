using AuthService.Application.Common.Mappings;
using AuthService.Application.RegisterAccount;
using AutoMapper;

namespace AuthService.WebApi.Models.Account
{
    /// <summary>
    /// Данные для регистрации нового пользователя.
    /// </summary>
    public class RegisterDto : IMapWith<RegisterAccountCommand>
    {
        /// <summary>
        /// Email пользователя. Используется как логин.
        /// </summary>
        /// <example>user@example.com</example>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Пароль. Должен соответствовать требованиям безопасности.
        /// </summary>
        /// <example>StrongP@ssw0rd15</example>
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, RegisterAccountCommand>()
                .ForMember(command => command.Email, options => options.MapFrom(dto => dto.Email))
                .ForMember(command => command.Password, options => options.MapFrom(dto => dto.Password));
        }
    }
}
