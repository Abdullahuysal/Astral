using Astral.PaymentIntegration.Core.Enums;

namespace Astral.PaymentIntegration.Core.Aggregates
{
    public record Payment
    {
        public Guid Id { get; private set; }
        public Guid ExternalId { get; private set; }
        public Guid MemberId { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public virtual Card Card { get; private set; }
        public virtual Pos Pos { get; private set; }
    }
}
