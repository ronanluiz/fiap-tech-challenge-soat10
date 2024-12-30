using Soat10.TechChallenge.Domain.Base;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Payment : Entity<string>
    {
        public Payment(string id, int orderId, decimal amount): base(id)
        {
            OrderId = orderId;
            Amount = amount;
        }

        public Order Order { get; set; }
        public int OrderId { get; private set; }
        public decimal Amount { get; private set; }
    }
}