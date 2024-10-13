namespace Astral.PaymentIntegration.Core.Aggregates
{
    public record Pos
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Payment> Payments { get; private set; }
        public virtual Bank Bank { get; private set; }

    }
}
