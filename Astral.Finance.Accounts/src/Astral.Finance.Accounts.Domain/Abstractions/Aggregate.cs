namespace Astral.Finance.Accounts.Domain.Abstractions
{
    public abstract class Aggregate
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        protected Aggregate(Guid id)
        {
            Id = id;
        }

        protected Aggregate()
        {
        }
        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
