namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class OrderPaymentStatusResponse
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string StatusPayment { get; set; }
        public string DetailedStatusPayment { get; set; }
        public decimal OrderValue { get; set; }
        public string CustomerName { get; set; }
    }
}
