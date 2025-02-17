namespace Soat10.TechChallenge.Application.Entities
{
    public class PaymentOrder
    {
        public PaymentOrder(string id, string qrData)
        {
            Id = id;
            QrData = qrData;
        }

        public string Id { get; private set; }
        public string QrData { get; private set; }
    }
}
