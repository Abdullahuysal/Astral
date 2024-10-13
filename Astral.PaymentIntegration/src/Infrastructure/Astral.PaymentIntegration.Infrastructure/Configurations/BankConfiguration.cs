using Astral.PaymentIntegration.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.PaymentIntegration.Infrastructure.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).
                ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasMany(x => x.Poses)
                .WithOne(x => x.Bank)
                .HasForeignKey(x => x.Bank.Id);
        }
    }
}
