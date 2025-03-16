using Astral.Finance.Accounts.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astral.Finance.Accounts.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(customer => customer.Id);

            builder.OwnsOne(customer => customer.FullName);

            builder.Property(customer => customer.Email)
                .HasMaxLength(200)
                .HasConversion(email => email.Value, value => new Email(value));

            builder.HasIndex(customer => customer.Email).IsUnique();

            builder.OwnsOne(customer => customer.Address);

            builder.Property(customer => customer.PhoneNumber)
                .HasMaxLength(20)
                .HasConversion(phoneNumber => phoneNumber.Value, value => new PhoneNumber(value));
        }
    }
}