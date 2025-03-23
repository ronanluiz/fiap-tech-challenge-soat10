using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class CheckoutRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid CartId { get; set; }
    }
}
