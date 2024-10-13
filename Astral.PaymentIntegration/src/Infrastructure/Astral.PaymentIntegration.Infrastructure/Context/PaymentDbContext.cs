using Astral.PaymentIntegration.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Astral.PaymentIntegration.Infrastructure.Context
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext()
        {
            
        }

        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PaymentConfiguration());

        }
    }
}
