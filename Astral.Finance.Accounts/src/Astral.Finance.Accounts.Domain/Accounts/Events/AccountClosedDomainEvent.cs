using Astral.Finance.Accounts.Domain.Abstractions;

namespace Astral.Finance.Accounts.Domain.Accounts.Events
{
    public record AccountClosedDomainEvent(Guid AccountId) : IDomainEvent;
}