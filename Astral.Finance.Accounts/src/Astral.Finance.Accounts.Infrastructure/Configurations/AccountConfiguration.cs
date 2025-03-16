using Astral.Finance.Accounts.Domain.Accounts;
using Astral.Finance.Accounts.Domain.Customers;
using Astral.Finance.Accounts.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.Finance.Accounts.Infrastructure.Configurations
{
    internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");

            builder.HasKey(x => x.Id);

            builder.Property(account => account.AccountNumber)
                .HasMaxLength(100)
                .HasConversion(accountNumber => accountNumber.Value, value => new AccountNumber(value));

            builder.OwnsOne(account => account.AccountNumber);

            builder.Property(account => account.Status)
                .IsRequired();

            builder.Property(account => account.Type)
                .IsRequired();

            builder.Property(account => account.CreateTime)
                .IsRequired();

            builder.Property(account => account.UpdateTime)
                .IsRequired();

            builder.OwnsOne(account => account.Amount, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(account => account.CustomerId);

        }
    }
}