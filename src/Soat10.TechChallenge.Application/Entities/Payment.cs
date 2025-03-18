namespace Soat10.TechChallenge.Application.Entities
{
    public class Payment : Entity<Guid>
    {
        public Payment(Order order, decimal totalAmount, string qrData) : base(Guid.NewGuid())
        {
            Order = order;
            OrderId = order.Id;
            TotalAmount = totalAmount;
            QrData = qrData;
            CreatedAt = DateTime.UtcNow;
        }

        public Payment(Guid id, 
            DateTime createdAt, 
            Order order, 
            decimal totalAmount, 
            string qrData, 
            string externalPaymentId, 
            DateTime? paidAt)
        {
            Id = id;
            CreatedAt = createdAt;
            Order = order;
            OrderId = order.Id;
            TotalAmount = totalAmount;
            QrData = qrData;
            ExternalPaymentId = externalPaymentId;
            PaidAt = paidAt;
        }

        public DateTime CreatedAt { get; private set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string QrData { get; private set; }
        public string ExternalPaymentId { get; private set; }
        public DateTime? PaidAt { get; private set; }

        public void SetExternalPayment(string externalPaymentId)
        {
            ExternalPaymentId = externalPaymentId;            
        }

        public void SetPaymentDate(DateTime paymentDate)
        {
            PaidAt = paymentDate;
        }


    }
}