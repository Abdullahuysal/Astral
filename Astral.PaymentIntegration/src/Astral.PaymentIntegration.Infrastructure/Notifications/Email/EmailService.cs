using Astral.PaymentIntegration.Application.Abstractions.Notifications.Email;

namespace Astral.PaymentIntegration.Infrastructure.Notifications.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(string email, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
