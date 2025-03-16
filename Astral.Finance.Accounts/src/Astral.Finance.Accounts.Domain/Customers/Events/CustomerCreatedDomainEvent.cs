using Astral.Finance.Accounts.Domain.Abstractions;

namespace Astral.Finance.Accounts.Domain.Customers.Events
{
    public record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;
}
