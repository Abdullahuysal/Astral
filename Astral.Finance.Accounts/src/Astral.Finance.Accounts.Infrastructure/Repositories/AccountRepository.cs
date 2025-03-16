using Astral.Finance.Accounts.Domain.Accounts;
using Astral.Finance.Accounts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Astral.Finance.Accounts.Infrastructure.Repositories
{
    internal sealed class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Account>> GetAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Account>()
                .Where(account => account.CustomerId == customerId)
                .ToListAsync(cancellationToken);
        }
    }
}
