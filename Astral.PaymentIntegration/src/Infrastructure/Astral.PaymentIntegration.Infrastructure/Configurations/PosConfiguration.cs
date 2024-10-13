using Astral.PaymentIntegration.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.PaymentIntegration.Infrastructure.Configurations
{
    public class PosConfiguration : IEntityTypeConfiguration<Pos>
    {
        public void Configure(EntityTypeBuilder<Pos> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasMany(x => x.Payments)
                .WithOne()
                .HasForeignKey(x =>x.Pos.Id);
        }
    }
}
