using Astral.PaymentIntegration.Domain.Abstractions;
using Astral.PaymentIntegration.Domain.Shared;

namespace Astral.PaymentIntegration.Domain.Payments
{
    public sealed class PaymentItem : Aggregate
    {
        public PaymentItem(
            Guid id,
            Guid paymentId,
            DateTime createTime,
            DateTime updateTime,
            Money price,
            Currency currency,
            PaymentStatus status) : base(id)
        {
            Id = id;
            PaymentId = paymentId;
            CreateTime = createTime;
            UpdateTime = updateTime;
            Price = price;
            Currency = currency;
            Status = status;
        }
        public Guid PaymentId { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public Money Price { get; private set; }
        public Currency Currency { get; private set; }
        public PaymentStatus Status { get; private set; }
    }
}
