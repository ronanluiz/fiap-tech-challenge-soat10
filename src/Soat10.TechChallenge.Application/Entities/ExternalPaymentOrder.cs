namespace Soat10.TechChallenge.Application.Entities
{
    public class ExternalPaymentOrder
    {
        public ExternalPaymentOrder(string id, Guid orderId, string status)
        {
            Id = id;
            OrderId = orderId;
            Status = status;
        }

        public string Id { get; private set; }
        public Guid OrderId { get; private set; }
        public string Status { get; set; }
    }
}
