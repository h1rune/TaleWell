using AuthService.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Web;

namespace AuthService.Infrastructure
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration config, ILogger<EmailService> logger, IWebHostEnvironment env)
        {
            _config = config;
            _logger = logger;
            var templatesPath = Path.Combine("Templates");
        }

        public async Task SendEmailConfirmationAsync(string to, string accountId, string token, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TaleWell", _config["Email:From"]));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = "Подтверждение почты";

            var confirmationLink = $"{_config["ConfirmLinks:Email"]}?accountId={accountId}&token={HttpUtility.UrlEncode(token)}";

            var viewData = new Dictionary<string, object>
            {
                ["Link"] = confirmationLink,
                ["LogoUrl"] = _config["LogoUrl"]!
            };

            var textVersion = $"Для подтверждения перейдите по ссылке:\n{confirmationLink}";

            await SendEmailAsync(message, textVersion, cancellationToken);
        }

        public async Task SendPasswordResetEmailAsync(string to, string userId, string token, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TaleWell", _config["Email:From"]));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = "Сброс пароля";

            var resetLink = $"{_config["ConfirmLinks:ResetPassword"]}?accountId={userId}&token={HttpUtility.UrlEncode(token)}";

            var viewData = new Dictionary<string, object>
            {
                ["Link"] = resetLink,
                ["LogoUrl"] = _config["LogoUrl"]!
            };

            var textVersion = $"Для сброса пароля перейдите по ссылке:\n{resetLink}";

            await SendEmailAsync(message, textVersion, cancellationToken);
        }

        private async Task SendEmailAsync(MimeMessage message, string plainText, CancellationToken cancellationToken)
        {
            var bodyBuilder = new BodyBuilder { TextBody = plainText };

            message.Body = bodyBuilder.ToMessageBody();

            try
            {
                using var client = new SmtpClient();
                await client.ConnectAsync(_config["Email:SMTP"], int.Parse(_config["Email:Port"]!), SecureSocketOptions.SslOnConnect, cancellationToken);
                await client.AuthenticateAsync(_config["Email:User"], _config["Email:Password"], cancellationToken);
                await client.SendAsync(message, cancellationToken);
                await client.DisconnectAsync(true, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при отправке email");
                throw;
            }
        }
    }
}
