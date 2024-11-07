namespace Astral.OrderIntegration.Core.Aggregates
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid MerchantId { get; private set; }
        public string ProductName { get; private set; }
        public decimal ListPrice { get; private set; }
        public decimal Discount { get; set; }
        public decimal SalePrice { get; private set; }
        public int Quantity { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        
        public OrderItem() { }

        public static OrderItem Create(Guid orderId, Guid productId, string productName, decimal listPrice, decimal discount, decimal salePrice, int quantity)
        {
            return new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = productId,
                ProductName = productName,
                ListPrice = listPrice,
                Discount = discount,
                SalePrice = salePrice,
                Quantity = quantity,
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            };
        }


    }
}
