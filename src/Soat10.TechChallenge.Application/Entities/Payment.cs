using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Payment : Entity<int>
    {
        public Payment(int id,  int orderId, decimal amount, string status, string? detailedStatus = null) : base(id)
        {
            Id = id;
            OrderId = orderId;
            Amount = amount;
            Status = status;
            DetailedStatus = detailedStatus;
        }

        public virtual Order Order { get; set; }
        public int OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public string Status { get; set; }
        public string DetailedStatus { get; set; }
    }
}