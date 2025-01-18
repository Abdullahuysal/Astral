using Astral.Finance.Accounts.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.Finance.Accounts.Infrastructure.Configurations
{
    public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts", "Finance");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(a => a.FullName, fullName =>
            {
                fullName.Property(f => f.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(50);
                fullName.Property(f => f.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(50);
            });

            builder.OwnsOne(a => a.Email, email =>
            {
                email.Property(e => e.value)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(255);
            });

            builder.OwnsOne(a => a.Address, address =>
            {
                address.Property(a => a.Street)
                    .HasColumnName("Street")
                    .IsRequired()
                    .HasMaxLength(255);

                address.Property(a => a.City)
                    .HasColumnName("City")
                    .IsRequired()
                    .HasMaxLength(255);

                address.Property(a => a.City)
                    .HasColumnName("City")
                    .IsRequired()
                    .HasMaxLength(255);

                address.Property(a => a.ZipCode)
                    .HasColumnName("ZipCode")
                    .IsRequired()
                    .HasMaxLength(255);

            });

            builder.OwnsOne(a => a.AccountNumber, accountNumber =>
            {
                accountNumber.Property(e => e.value)
                    .HasColumnName("AccountNumber")
                    .IsRequired()
                    .HasMaxLength(255);
            });

            builder.Property(a => a.Status)
                .HasConversion(
                    status => status.ToString(),
                    value => Enum.Parse<AccountStatus>(value)
                )
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.Type)
                .HasConversion(
                    status => status.ToString(),
                    value => Enum.Parse<AccountType>(value)
                )
                .HasMaxLength(20)
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
