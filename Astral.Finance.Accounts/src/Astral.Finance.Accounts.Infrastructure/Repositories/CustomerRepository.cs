using Astral.Finance.Accounts.Domain.Customers;
using Astral.Finance.Accounts.Infrastructure.Context;

namespace Astral.Finance.Accounts.Infrastructure.Repositories
{
    internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
