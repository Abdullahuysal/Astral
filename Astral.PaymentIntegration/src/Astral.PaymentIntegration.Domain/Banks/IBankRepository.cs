namespace Astral.PaymentIntegration.Domain.Banks
{
    public interface IBankRepository
    {
        Task<Bank?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
