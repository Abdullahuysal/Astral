using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.PaymentIntegration.Infrastructure.Configurations
{
    public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payments", "sales");

            builder.HasKey(payment => payment.Id);

            builder.Property(payment => payment.MemberId)
                .IsRequired();

            builder.Property(payment => payment.ExternalCode)
                .IsRequired()
                .HasConversion(name => name.Value, value => new ExternalCode(value));

            builder.HasIndex(payment => payment.ExternalCode).IsUnique();

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

            builder.Property(payment => payment.IsConfirmed)
                .IsRequired();
        }
    }
}
