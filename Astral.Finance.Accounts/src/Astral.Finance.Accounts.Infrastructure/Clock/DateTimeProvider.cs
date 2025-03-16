using Astral.Finance.Accounts.Application.Abstractions.Clock;

namespace Astral.Finance.Accounts.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
