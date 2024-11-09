using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Infrastructure.Context;

namespace Astral.PaymentIntegration.Infrastructure.Repositories
{
    internal sealed class PaymentItemRepository : Repository<PaymentItem>, IPaymentItemRepository
    {
        public PaymentItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
