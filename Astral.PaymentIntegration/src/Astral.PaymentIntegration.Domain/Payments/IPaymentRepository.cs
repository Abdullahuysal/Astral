namespace Astral.PaymentIntegration.Domain.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(Payment payment);
    }
}
