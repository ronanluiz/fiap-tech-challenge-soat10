namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class OrderPaymentStatusResponse
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDetailedStatus { get; set; }
        public decimal OrderValue { get; set; }
        public string CustomerName { get; set; }
    }
}
