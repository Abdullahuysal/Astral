namespace Astral.Finance.Accounts.Domain.Accounts
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
