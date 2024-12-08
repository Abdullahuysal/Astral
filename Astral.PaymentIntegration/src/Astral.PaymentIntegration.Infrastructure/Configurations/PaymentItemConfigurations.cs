using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.PaymentIntegration.Infrastructure.Configurations
{
    public sealed class PaymentItemConfigurations : IEntityTypeConfiguration<PaymentItem>
    {
        public void Configure(EntityTypeBuilder<PaymentItem> builder)
        {
            builder.ToTable("paymentitems","sales");

            builder.HasKey(paymentItem => paymentItem.Id);

            builder.Property(payment => payment.PaymentId)
                .IsRequired();

            builder.Property(payment => payment.CreateTime)
                .IsRequired();

            builder.Property(payment => payment.UpdateTime)
                .IsRequired();

            builder.OwnsOne(payment => payment.Price, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.Property(payment => payment.Currency)
                .HasConversion(
                    currency => currency.Code,
                    code => Currency.FromCode(code)
                )
                .IsRequired();

            builder.Property(payment => payment.Status)
                .IsRequired();

            builder.HasOne<Payment>()
                .WithMany()
                .HasForeignKey(payment => payment.PaymentId);
        }
    }
}
