using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Customers;

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
            DateTime createTime,
            DateTime updateTime
            ) : base(id)
        {

        }

        private Account()
        {

        }
    }
}
