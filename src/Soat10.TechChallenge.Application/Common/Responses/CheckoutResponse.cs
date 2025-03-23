namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class CheckoutResponse
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string QrData { get; set; }
    }
}
