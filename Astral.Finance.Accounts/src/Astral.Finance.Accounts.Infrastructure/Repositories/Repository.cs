using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Astral.Finance.Accounts.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Aggregate
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }
    }
}
