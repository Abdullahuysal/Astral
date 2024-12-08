using Astral.PaymentIntegration.Domain.Banks;
using Astral.PaymentIntegration.Infrastructure.Context;

namespace Astral.PaymentIntegration.Infrastructure.Repositories
{
    internal sealed class BankRepository : Repository<Bank> , IBankRepository
    {
        public BankRepository(ApplicationDbContext dbContext) : 
            base(dbContext)
        {
            
        }
    }
}
