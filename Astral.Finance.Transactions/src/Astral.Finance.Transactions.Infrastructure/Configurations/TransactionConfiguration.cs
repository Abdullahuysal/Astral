using Astral.Finance.Transactions.Domain.Aggregates.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.Finance.Transactions.Infrastructure.Configurations
{
    public sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions", "Finance");

            builder.HasKey(x => x.Id);


            builder.Property(a => a.SenderAccountId)
            .HasColumnName("SenderAccountId")
            .IsRequired();

            builder.Property(a => a.ReceiverAccountId)
            .HasColumnName("ReceiverAccountId")
            .IsRequired();

            builder.Property(t => t.Amount)
            .HasColumnType("NUMERIC(18,2)")
            .IsRequired();

            builder.Property(a => a.Currency)
            .HasColumnName("Currency")
            .IsRequired();

            builder.Property(a => a.Type)
            .HasColumnName("Type")
            .IsRequired();

            builder.Property(a => a.Status)
            .HasColumnName("Status")
            .IsRequired();

            builder.Property(a => a.CreateTime)
            .HasColumnName("CreateTime")
            .IsRequired();

            builder.Property(a => a.UpdateTime)
            .HasColumnName("UpdateTime")
            .IsRequired();

        }
    }
}
