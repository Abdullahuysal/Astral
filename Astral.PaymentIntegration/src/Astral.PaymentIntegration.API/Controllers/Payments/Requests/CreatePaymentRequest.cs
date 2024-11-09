using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Domain.Shared;

namespace Astral.PaymentIntegration.API.Controllers.Payments.Requests
{
    public sealed record CreatePaymentRequest(
        Guid MemberId,
        ExternalCode ExternalCode,
        Money Price,
        Currency Currency
        );
}