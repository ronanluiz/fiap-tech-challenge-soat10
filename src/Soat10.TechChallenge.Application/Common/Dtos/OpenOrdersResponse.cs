namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OpenOrdersResponse
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Products { get; set; }
        public string CreatedAt { get; set; }
        public string CustomerName { get; set; }
    }
}
