using Astral.PaymentIntegration.Domain.Abstractions;
using Astral.PaymentIntegration.Domain.Payments.Events;

namespace Astral.PaymentIntegration.Domain.Payments
{
    public sealed class Payment : Aggregate
    {
        public Payment(
            Guid id,
            Guid memberId,
            ExternalCode externalCode,
            DateTime createTime,
            DateTime updateTime,
            Money price,
            Currency currency,
            bool isConfirmed,
            PaymentStatus paymentStatus) : base(id)
        {
            MemberId = memberId;
            ExternalCode = externalCode;
            CreateTime = createTime;
            UpdateTime = updateTime;
            Price = price;
            Currency = currency;
            IsConfirmed = isConfirmed;
            Status = paymentStatus;
        }

        public Guid MemberId { get; private set; }
        public ExternalCode ExternalCode { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public Money Price { get; private set; }
        public Currency Currency { get; private set; }
        public PaymentStatus Status { get; private set; }
        public bool IsConfirmed { get; private set; }
        public List<PaymentItem> PaymentItems { get; private set; } = new();

        public static Payment Create(Guid memberId, ExternalCode externalCode, Money price, Currency currency, bool isConfirmed, List<PaymentItem> paymentItems)
        {
            var payment = new Payment(Guid.NewGuid(), memberId, externalCode, DateTime.UtcNow, DateTime.UtcNow, price, currency, isConfirmed, PaymentStatus.Pending);
            payment.RaiseDomainEvent(new PaymentCreateDomainEvent(payment.Id));
            return payment;
        }

        public Result Complete()
        {
            if (Status != PaymentStatus.ThreeDWaiting)
            {
                return Result.Failure(PaymentErrors.ThreeDNotCompleted);
            }

            Status = PaymentStatus.Success;
            UpdateTime = DateTime.UtcNow;

            RaiseDomainEvent(new PaymentCompleteDomainEvent(Id));

            return Result.Success();
        }

    }
}
