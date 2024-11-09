using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Domain.Shared;

namespace Astral.PaymentIntegration.Application.Payments.GetPayment
{
    public sealed class PaymentResponse
    {
        public Guid Id { get; init; }
        public Guid MemberId { get; init; }
        public ExternalCode ExternalCode { get; init; }
        public DateTime CreateTime { get; init; }
        public DateTime UpdateTime { get; init; }
        public Money Price { get; init; }
        public Currency Currency { get; init; }
        public PaymentStatus Status { get; init; }
    }
}
