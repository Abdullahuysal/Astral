using Astral.Finance.Accounts.Application.Abstractions.Messaging;
using Astral.Finance.Accounts.Domain.Shared;

namespace Astral.Finance.Accounts.Application.Accounts.CreateAccount
{
    public record CreateAccountCommand(
        FullName FullName,
        Email Email,
        Address Address,
        AccountNumber AccountNumber)
        : ICommand<Guid>;
}
