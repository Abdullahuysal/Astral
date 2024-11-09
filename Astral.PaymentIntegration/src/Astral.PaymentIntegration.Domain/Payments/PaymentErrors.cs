using Astral.PaymentIntegration.Domain.Abstractions;

namespace Astral.PaymentIntegration.Domain.Payments
{
    public static class PaymentErrors
    {
        public static Error NotFound = new(
            "Payment.NotFound",
            "The Payment with the specified identifiew was not found");

        public static Error Overlap = new(
            "Payment.Overlap",
            "The Payment create was overlaped");

        public static Error NotCompleted = new(
           "Payment.NotCompleted",
           "The Payment is not completed");

        public static Error AlreadyCompleted = new(
            "Payment.AlreadyCompleted",
            "The Payment is already completed");

        public static Error ThreeDNotCompleted = new(
            "Payment.ThreeDNotCompleted",
            "The ThreeD Payment is not completed");

    }
}
