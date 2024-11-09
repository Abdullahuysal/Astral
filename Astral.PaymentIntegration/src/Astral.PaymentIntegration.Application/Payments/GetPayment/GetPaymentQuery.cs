using Astral.PaymentIntegration.Application.Abstractions.Messaging;

namespace Astral.PaymentIntegration.Application.Payments.GetPayment
{
    public record GetPaymentQuery(Guid paymentId) : IQuery<PaymentResponse>;
}
