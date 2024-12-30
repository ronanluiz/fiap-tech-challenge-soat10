namespace Soat10.TechChallenge.Application.UseCases.Checkout
{
    public class CheckoutRequest
    {
        public int OrderNumber { get; set; }
        public string PaymentQrCode { get; set; }
    }
}
