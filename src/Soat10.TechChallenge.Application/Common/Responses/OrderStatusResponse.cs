using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class OrderStatusResponse
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
    }
}
