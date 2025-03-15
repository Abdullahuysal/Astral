using Astral.Finance.Transactions.Domain.Abstractions;

namespace Astral.Finance.Transactions.Domain.Aggregates.Transactions
{
    public class Transaction : Aggregate
    {
        public Transaction(
            Guid id,
            Guid senderAccountId,
            Guid receiverAccountId,
            decimal amount,
            string currency,
            TransactionType type,
            TransactionStatus status,
            DateTime createTime,
            DateTime updateTime
            ) : base(id)
        {

        }

        private Transaction()
        {

        }


        public Guid SenderAccountId { get; private set; }
        public Guid ReceiverAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public TransactionType Type { get; private set; }
        public TransactionStatus Status { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
    }
}
