using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Infrastructure.Context;

namespace Astral.PaymentIntegration.Infrastructure.Repositories
{
    internal sealed class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
