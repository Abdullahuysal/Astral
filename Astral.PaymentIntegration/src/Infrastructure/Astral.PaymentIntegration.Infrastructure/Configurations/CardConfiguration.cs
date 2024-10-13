using Astral.PaymentIntegration.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.PaymentIntegration.Infrastructure.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).
                ValueGeneratedOnAdd();

            builder.Property(x => x.CardHolderName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CardNumber)
                .HasMaxLength(16)
                .IsRequired();
            
            builder.Property(x => x.ExpireYear)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(x => x.ExpireMonth)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Cvv)
                .HasMaxLength(3)
                .IsRequired();

        }
    }
}
