using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; private set; }

        public Guid OrderId { get; private set; }

        public decimal Amount { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        public string Status { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        public string? DetailedStatus { get; set; } 
    }
}