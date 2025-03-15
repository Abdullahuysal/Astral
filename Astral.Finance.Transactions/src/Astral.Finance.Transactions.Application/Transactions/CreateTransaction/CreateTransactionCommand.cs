using Astral.Finance.Transactions.Application.Abstractions.Messaging;

namespace Astral.Finance.Transactions.Application.Transactions.CreateTransaction
{
    public record CreateTransactionCommand(
        Guid SenderAccountId,
        Guid ReceiverAccountId,
        decimal Amount,
        string Currency
        ) : ICommand<Guid>;
}
