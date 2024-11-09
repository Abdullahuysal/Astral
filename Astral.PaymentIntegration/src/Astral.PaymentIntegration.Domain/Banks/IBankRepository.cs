using Astral.PaymentIntegration.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.PaymentIntegration.Domain.Banks
{
    public interface IBankRepository
    {
        Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
