namespace Astral.OrderIntegration.Core.Aggregates
{
    public class OrderHistory
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime ActionTime { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public OrderHistory() { }
    }
}
