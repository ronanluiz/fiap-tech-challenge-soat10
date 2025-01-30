namespace Soat10.TechChallenge.Application.UseCases.GetOrders
{
    public class GetOrdersResponse
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public int CustumerId { get; set; }
        public string CustomerName { get; set; }
        public string Items { get; set; }
        public decimal Amount { get; set; }

    }
}