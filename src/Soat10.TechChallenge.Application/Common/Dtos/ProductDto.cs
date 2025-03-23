using Soat10.TechChallenge.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-.,']*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")] 
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")] 
        [RegularExpression(@"^[a-zA-Z0-9\s\-.,']*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")]  
        public string? Description { get; set; } 

        public CategoryEnum ProductCategory { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O campo {0} deve ser maior que zero.")] 
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "O campo {0} deve ter no máximo duas casas decimais.")]
        public decimal Price { get; set; }

        public ProductStatus Status { get; set; }

        public TimeSpan TimeToPrepare { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [StringLength(256, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string? UserUpdated { get; set; }
    }
}