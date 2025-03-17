namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class CheckoutResponse
    {
        public Guid OrderId { get; set; }
        public string QrData { get; set; }
    }
}
