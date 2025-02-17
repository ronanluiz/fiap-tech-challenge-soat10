namespace Soat10.TechChallenge.Application.Entities
{
    public class Payment : Entity<string>
    {
        public Payment(string id, int orderId, decimal amount) : base(id)
        {
            OrderId = orderId;
            Amount = amount;
        }

        public virtual Order Order { get; set; }
        public int OrderId { get; private set; }
        public decimal Amount { get; private set; }
    }
}