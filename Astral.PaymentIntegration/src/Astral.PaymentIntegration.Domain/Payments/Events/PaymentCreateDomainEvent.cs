using Astral.PaymentIntegration.Domain.Abstractions;

namespace Astral.PaymentIntegration.Domain.Payments.Events
{
    public sealed record PaymentCreateDomainEvent(Guid paymentId) : IDomainEvent;
}
