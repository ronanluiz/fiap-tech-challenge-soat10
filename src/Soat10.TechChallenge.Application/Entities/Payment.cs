using Soat10.TechChallenge.Application.Enums;

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

        public Payment(Guid id, Guid orderId, decimal totalAmount, string status, string? detailedStatus = null) : base(id)
        {
            Id = id;
            OrderId = orderId;
            TotalAmount = totalAmount;
            Status = status;
            DetailedStatus = detailedStatus;
        }

        public DateTime CreatedAt { get; private set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Status { get; set; }
        public string DetailedStatus { get; set; }
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