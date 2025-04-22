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
        public string Email { get; set; } = null!;

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        /// <example>MySecurePassword123!</example>
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginCommand>()
                .ForMember(command => command.Email, options => options.MapFrom(dto => dto.Email))
                .ForMember(command => command.Password, options => options.MapFrom(dto => dto.Password));
        }
    }
}
