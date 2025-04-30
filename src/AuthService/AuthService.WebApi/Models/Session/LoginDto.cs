using AuthService.Application.Common.Mappings;
using AuthService.Application.Login;
using AutoMapper;

namespace AuthService.WebApi.Models.Session
{
    /// <summary>
    /// Данные для входа пользователя.
    /// </summary>
    public class LoginDto : IMapWith<LoginCommand>
    {
        /// <summary>
        /// Email пользователя.
        /// </summary>
        /// <example>user@example.com</example>
        public required string Email { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        /// <example>MySecurePassword123!</example>
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginCommand>()
                .ForMember(command => command.Email, options => options.MapFrom(dto => dto.Email))
                .ForMember(command => command.Password, options => options.MapFrom(dto => dto.Password));
        }
    }
}
