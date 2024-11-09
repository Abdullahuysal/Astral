namespace Astral.PaymentIntegration.Domain.Payments
{
    public interface IPaymentItemRepository
    {
        Task<PaymentItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(PaymentItem paymentItem);
    }
}
