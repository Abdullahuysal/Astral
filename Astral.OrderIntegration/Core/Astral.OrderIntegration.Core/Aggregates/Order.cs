namespace Astral.OrderIntegration.Core.Aggregates
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; set; }
        public string OrderNumber { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string Status { get; private set; }
        public string PaymentMethod { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

        public Order() {  }

        public static Order Create(Guid customerId, string orderNumber, decimal totalAmount, DateTime orderDate, string status, string paymentMethod, List<OrderItem> orderItems)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                OrderNumber = orderNumber,
                TotalAmount = totalAmount,
                OrderDate = orderDate,
                Status = status,
                PaymentMethod = paymentMethod,
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow,
                OrderItems = orderItems ?? new List<OrderItem>()
            };
        }


    }
}
