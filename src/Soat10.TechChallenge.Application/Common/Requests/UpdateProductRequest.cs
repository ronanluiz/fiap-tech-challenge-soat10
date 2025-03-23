using Soat10.TechChallenge.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class UpdateProductRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-.,']*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-.,']*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EnumDataType(typeof(CategoryEnum), ErrorMessage = "O valor do campo {0} é inválido.")]
        public CategoryEnum ProductCategory { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O campo {0} deve ser maior que zero.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "O campo {0} deve ter no máximo duas casas decimais.")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(typeof(TimeSpan), "00:00:01", "23:59:59", ErrorMessage = "O {0} deve estar entre 00:00:01 e 23:59:59")]
        public TimeSpan? TimeToPrepare { get; set; }
    }
}