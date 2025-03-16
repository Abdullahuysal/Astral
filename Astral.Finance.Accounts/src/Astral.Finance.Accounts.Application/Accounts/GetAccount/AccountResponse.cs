namespace Astral.Finance.Accounts.Application.Accounts.GetAccount
{
    public sealed class AccountResponse
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public string AccountNumber { get; init; }
        public int Status { get; init; }
        public int Type { get; init; }
        public DateTime CreateTime { get; init; }
        public DateTime UpdateTime { get; init; }
        public decimal Amount { get; init; }
    }
}
