using Astral.Finance.Accounts.Application.Abstractions.Messaging;

namespace Astral.Finance.Accounts.Application.Accounts.GetAccount
{
    public sealed record GetAccountQuery(Guid AccountId) : IQuery<AccountResponse>;
}
