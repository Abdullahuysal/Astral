namespace Astral.Finance.Accounts.Domain.Customers
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
