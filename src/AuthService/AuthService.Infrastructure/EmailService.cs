using AuthService.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Web;

namespace AuthService.Infrastructure
{
    public class EmailService(IConfiguration config) : IEmailService
    {
        private readonly IConfiguration _config = config;

        public async Task SendEmailConfirmationAsync(string to, string accountId, string token, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TaleWell", _config["Email:From"]));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = "Подтверждение почты";
            var link = $"{_config["Email:ConfirmLink"]}?accountId={accountId}&token={HttpUtility.UrlEncode(token)}";
            message.Body = new TextPart("plain") { Text = $"Для подтвержения перейдите по ссылке: {link}" };

            using var client = new SmtpClient();
            await client.ConnectAsync(_config["Email:SMTP"], int.Parse(_config["Email:Port"]!), SecureSocketOptions.StartTls, cancellationToken);
            await client.AuthenticateAsync(_config["Email:User"], _config["Email:Password"], cancellationToken);
            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}
