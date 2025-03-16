namespace Astral.Finance.Accounts.Domain.Abstractions
{
    public abstract class Aggregate
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        protected Aggregate(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return [.. _domainEvents];
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
