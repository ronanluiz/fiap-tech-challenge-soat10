using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class CartCreationRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? CustomerId { get; set; } 

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        [RegularExpression(@"^[a-zA-Z\s'-]*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")] 
        public string CustomerName { get; set; }
    }
}