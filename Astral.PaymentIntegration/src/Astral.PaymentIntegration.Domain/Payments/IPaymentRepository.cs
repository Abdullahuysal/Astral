namespace Astral.PaymentIntegration.Domain.Payments
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);

        Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
