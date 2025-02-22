namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class PaymentDao
    {
        public int Id { get; set; }
        public virtual OrderDao Order { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
