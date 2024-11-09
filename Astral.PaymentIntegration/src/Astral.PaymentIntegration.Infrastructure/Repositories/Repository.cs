using Astral.PaymentIntegration.Domain.Abstractions;
using Astral.PaymentIntegration.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Astral.PaymentIntegration.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Aggregate
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }
    }
}
