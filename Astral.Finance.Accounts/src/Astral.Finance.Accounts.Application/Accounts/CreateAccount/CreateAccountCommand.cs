using Astral.Finance.Accounts.Application.Abstractions.Messaging;
using Astral.Finance.Accounts.Domain.Accounts;
using Astral.Finance.Accounts.Domain.Shared;

namespace Astral.Finance.Accounts.Application.Accounts.CreateAccount
{
    public record CreateAccountCommand(
            Guid CustomerId,
            AccountNumber AccountNumber,
            AccountType AccountType) : ICommand<Guid>;
}
