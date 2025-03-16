using Astral.Finance.Accounts.Domain.Abstractions;

namespace Astral.Finance.Accounts.Domain.Accounts.Events
{
    public record AccountCreatedDomainEvent(Guid AccountId) : IDomainEvent;
}
