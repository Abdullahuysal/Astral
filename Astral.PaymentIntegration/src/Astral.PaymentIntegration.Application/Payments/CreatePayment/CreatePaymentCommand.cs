using Astral.PaymentIntegration.Application.Abstractions.Messaging;
using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Domain.Shared;

namespace Astral.PaymentIntegration.Application.Payments.CreatePayment
{
    public record CreatePaymentCommand(
        Guid MemberId,
        ExternalCode ExternalCode,
        Money Price,
        Currency Currency)
        : ICommand<Guid>;
}
