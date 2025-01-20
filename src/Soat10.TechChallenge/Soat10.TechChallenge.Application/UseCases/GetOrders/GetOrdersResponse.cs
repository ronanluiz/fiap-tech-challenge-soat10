using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Application.UseCases.GetOrders
{
    public class GetOrdersResponse
    {
        public string Status { get; set; }
        public string CustumerId { get; set; }
        public string CustomerName { get; set; }
        public string Items { get; set; }
        public decimal Amount { get; set; }

    }
}