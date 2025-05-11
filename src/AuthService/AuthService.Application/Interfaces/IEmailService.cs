namespace AuthService.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailConfirmationAsync(string to, string accountId, string token, CancellationToken cancellationToken);
        Task SendPasswordResetEmailAsync(string to, string accountId, string token, CancellationToken cancellationToken);
    }
}
