namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public string Status { get; set; }
        public string DetailedStatus { get; set; }
    }
}
