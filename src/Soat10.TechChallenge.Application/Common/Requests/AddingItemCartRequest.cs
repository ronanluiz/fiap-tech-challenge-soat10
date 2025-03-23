using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class AddingItemCartRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A {0} deve ser maior que zero.")]  
        public int Quantity { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        public string? Notes { get; set; }
    }
}