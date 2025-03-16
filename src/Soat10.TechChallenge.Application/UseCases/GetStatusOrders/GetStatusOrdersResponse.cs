namespace Soat10.TechChallenge.Application.UseCases.GetStatusOrders
{
    public class GetStatusOrdersResponse
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Products { get; set; }

        public GetStatusOrdersResponse(int orderId, string status, decimal amount, string products)
        {
            OrderId = orderId;
            Status = status;
            Amount = amount;
            Products = products;
        }
    }
}
