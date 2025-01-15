using Soat10.TechChallenge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.ProductApplication.Requests
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(50, ErrorMessage = "O nome do produto deve conter no máximo 50 caracteres.")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "A descrição do produto deve conter no máximo 200 caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
        public CategoryEnum ProductCategory { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Price { get; set; }

        [MaxLength(500, ErrorMessage = "A nota do produto deve conter no máximo 500 caracteres.")]
        public string? Note { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
        public int QuantityInStock { get; set; }

        [Range(typeof(TimeSpan), "00:00:00", "00:50:00", ErrorMessage = "O tempo para preparar deve estar entre 0 e 50 minutos.")]
        public TimeSpan TimeToPrepare { get; set; }

    }
}
