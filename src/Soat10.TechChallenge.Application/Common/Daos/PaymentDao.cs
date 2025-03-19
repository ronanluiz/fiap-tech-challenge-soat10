namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class PaymentDao
    {
        public Guid Id { get; set; }        
        public DateTime CreatedAt { get; set; }
        public virtual OrderDao Order { get; set; }
        public Guid OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string DetailedStatus { get; set; }

        public string QrData { get; set; }
        public string ExternalPaymentId { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
