namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class AddingItemCartRequest
    {   
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
