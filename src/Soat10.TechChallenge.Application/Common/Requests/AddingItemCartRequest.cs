namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class AddingItemCartRequest
    {   
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
