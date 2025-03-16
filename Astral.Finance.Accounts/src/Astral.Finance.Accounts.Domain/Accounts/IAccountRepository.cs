namespace Astral.Finance.Accounts.Domain.Accounts
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Account>> GetAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    }
}
