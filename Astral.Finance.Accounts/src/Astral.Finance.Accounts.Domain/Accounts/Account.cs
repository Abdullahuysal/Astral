using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Accounts.Events;
using Astral.Finance.Accounts.Domain.Shared;

namespace Astral.Finance.Accounts.Domain.Accounts
{
    public sealed class Account : Aggregate
    {
        private Account(
            Guid id,
            Guid customerId,
            AccountNumber accountNumber,
            AccountStatus status,
            AccountType accountType,
            DateTime createTime,
            DateTime updateTime,
            Money amount)
            : base(id)
        {
            CustomerId = customerId;
            AccountNumber = accountNumber;
            Status = status;
            Type = accountType;
            CreateTime = createTime;
            UpdateTime = updateTime;
            Amount = amount;
        }
        public Guid CustomerId { get; private set; }
        public AccountNumber AccountNumber { get; private set; }
        public AccountStatus Status { get; private set; }
        public AccountType Type { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public Money Amount { get; private set; }

        public static Account Create(Guid customerId, AccountNumber accountNumber, AccountType accountType, DateTime createTime, DateTime updateTime)
        {
            var account = new Account(Guid.NewGuid(), customerId, accountNumber, AccountStatus.Active, accountType, createTime, updateTime, Money.Zero());

            account.RaiseDomainEvent(new AccountCreatedDomainEvent(account.Id));

            return account;
        }

        public Result Close()
        {
            if (Status != AccountStatus.Active || !Amount.IsZero() || CreateTime < DateTime.UtcNow.AddHours(1))
            {
                return Result.Failure(AccountErrors.NotClosed);
            }

            Status = AccountStatus.Closed;
            UpdateTime = DateTime.UtcNow;

            RaiseDomainEvent(new AccountClosedDomainEvent(Id));

            return Result.Success();
        }
    }
}
