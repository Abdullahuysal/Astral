namespace Astral.PaymentIntegration.Application.Abstractions.Notifications.Email
{
    public interface IEmailService
    {
        Task SendAsync(string email, string subject, string body);
    }
}
