namespace Astral.Finance.Transactions.Domain.Abstractions
{
    public abstract class Aggregate
    {
        protected Aggregate(Guid id)
        {
            Id = id;
        }

        protected Aggregate()
        {
        }

        public Guid Id { get; init; }

    }
}
