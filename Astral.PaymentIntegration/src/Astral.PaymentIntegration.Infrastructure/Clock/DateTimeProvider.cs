using Astral.PaymentIntegration.Application.Abstractions.Clock;

namespace Astral.PaymentIntegration.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
