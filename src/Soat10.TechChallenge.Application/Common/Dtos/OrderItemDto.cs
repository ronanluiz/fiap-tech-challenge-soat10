using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public virtual ProductDto Product { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A {0} deve ser maior que zero.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O campo {0} deve ser maior que zero.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "O campo {0} deve ter no máximo duas casas decimais.")] 
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        [RegularExpression(@"^[a-zA-Z0-9\s,.;:-]*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")] 
        public string? Note { get; set; }
    }
}