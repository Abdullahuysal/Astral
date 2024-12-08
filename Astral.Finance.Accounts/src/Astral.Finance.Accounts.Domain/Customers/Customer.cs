using Astral.Finance.Accounts.Domain.Abstractions;

namespace Astral.Finance.Accounts.Domain.Customers
{
    public sealed class Customer : Aggregate
    {
        public Customer(
            Guid id,
            CustomerType type,
            FullName fullName,
            Email email,
            DateTime birthDate,
            Address address,
            PhoneNumber phoneNumber,
            bool isVerified,
            CustomerStatus status
            ) : base(id)
        {
            Type = type;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Address = address;
            PhoneNumber = phoneNumber;
            IsVerified = isVerified;
            Status = status;
        }

        private Customer()
        {

        }

        public CustomerType Type { get; private set; }
        public FullName FullName { get; private set; }
        public Email Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public bool IsVerified { get; private set; } = false;
        public CustomerStatus Status { get; private set; }
    }
}
