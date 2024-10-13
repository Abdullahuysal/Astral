namespace Astral.PaymentIntegration.Core.Aggregates
{
    public record Card
    {
        public Guid Id { get; private set; }
        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string ExpireYear { get; private set; }
        public string ExpireMonth { get; private set; }
        public string Cvv { get; private set; }
        public Guid BankId { get; set; }

    }
}
