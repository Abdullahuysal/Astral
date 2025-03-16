using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Customers.Events;

namespace Astral.Finance.Accounts.Domain.Customers
{
    public sealed class Customer : Aggregate
    {
        private Customer(
            Guid id,
            FullName fullName,
            Email email,
            Address address,
            PhoneNumber phoneNumber)
            : base(id)
        {
            FullName = fullName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
        }


        public FullName FullName { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public static Customer Create(FullName fullName, Email email, Address address, PhoneNumber phoneNumber)
        {
            var customer = new Customer(Guid.NewGuid(), fullName, email, address, phoneNumber);

            customer.RaiseDomainEvent(new CustomerCreatedDomainEvent(customer.Id));

            return customer;
        }
    }
}
