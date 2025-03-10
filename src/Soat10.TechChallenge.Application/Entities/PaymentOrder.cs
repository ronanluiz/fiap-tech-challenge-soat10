namespace Soat10.TechChallenge.Application.Entities
{
    public class PaymentOrder
    {
        public PaymentOrder(string id, string orderId, string status)
        {
            Id = id;
            OrderId = orderId;
            Status = status;
        }

        public string Id { get; private set; }
        public string OrderId { get; private set; }
        public string Status { get; set; }
    }
}
