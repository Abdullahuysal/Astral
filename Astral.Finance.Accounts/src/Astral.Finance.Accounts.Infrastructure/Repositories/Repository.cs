using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Astral.Finance.Accounts.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Aggregate
    {
        protected readonly ApplicationDbContext _dbContext;

        protected Repository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<T>()
                .FirstAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }
    }
}
