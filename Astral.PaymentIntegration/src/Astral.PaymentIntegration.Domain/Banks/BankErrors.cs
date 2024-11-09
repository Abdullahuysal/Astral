using Astral.PaymentIntegration.Domain.Abstractions;

namespace Astral.PaymentIntegration.Domain.Banks
{
    public static class BankErrors
    {
        public static Error NotFound = new(
            "Bank.NotFound",
            "The Bank with the specified identifiew was not found");
    }
}
