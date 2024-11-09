using Astral.PaymentIntegration.Domain.Abstractions;

namespace Astral.PaymentIntegration.Domain.Banks
{
    public class Bank : Aggregate
    {
        public Bank(Guid id) : base(id)
        {
        }


    }
}
