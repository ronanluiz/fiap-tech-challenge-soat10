using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OpenOrdersResponse
    {
        // ID:  Geralmente gerado pelo *servidor*, não pelo cliente.  Portanto, *não* validamos no DTO de *registro*.
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]  
        public string Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "O campo {0} deve ser maior ou igual a zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Products { get; set; }

        // CreatedAt: Gerado pelo *servidor*, *não* pelo cliente.  Não validamos no DTO de registro.
        public string CreatedAt { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        [RegularExpression(@"^[a-zA-Z\s'-]*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")] 
        public string? CustomerName { get; set; }
    }
}