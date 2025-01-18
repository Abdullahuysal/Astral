using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Shared;

namespace Astral.Finance.Accounts.Domain.Accounts
{
    public sealed class Account : Aggregate
    {
        public Account(
            Guid id,
            FullName fullName,
            Email email,
            Address address,
            AccountNumber accountNumber,
            AccountStatus status,
            AccountType accountType,
            DateTime createTime,
            DateTime updateTime
            ) : base(id)
        {

        }

        private Account()
        {

        }

        public FullName FullName { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public AccountNumber AccountNumber { get; private set; }
        public AccountStatus Status { get; private set; }
        public AccountType Type { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }

        public static Account Create(
            FullName fullName,
            Email email,
            Address address,
            AccountNumber accountNumber,
            AccountStatus status,
            AccountType accountType)
        {
            return new Account(
                Guid.NewGuid(),
                fullName,
                email,
                address,
                accountNumber,
                status,
                accountType,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        private void UpdateLastModifiedTime()
        {
            UpdateTime = DateTime.UtcNow;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
            UpdateLastModifiedTime();
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
            UpdateLastModifiedTime();
        }

        public void UpdateFullName(FullName fullName)
        {
            FullName = fullName;
            UpdateLastModifiedTime();
        }
    }
}

