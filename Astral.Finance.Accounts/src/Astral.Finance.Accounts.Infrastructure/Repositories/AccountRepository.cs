using Astral.Finance.Accounts.Domain.Accounts;
using Astral.Finance.Accounts.Infrastructure.Context;

namespace Astral.Finance.Accounts.Infrastructure.Repositories
{
    internal sealed class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext) :
            base(dbContext)
        {

        }
    }
}
