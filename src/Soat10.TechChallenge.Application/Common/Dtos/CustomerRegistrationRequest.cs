using Soat10.TechChallenge.Application.Entities;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class CustomerRegistrationRequest
    {
        // ID:  Geralmente gerado pelo *servidor*, não pelo cliente.  Portanto, *não* validamos no DTO de *registro*.
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s'-]*$", ErrorMessage = "O campo {0} contém caracteres inválidos.")]
        public string Name { get; set; }

        // CreatedAt: Gerado pelo *servidor*, *não* pelo cliente.  Não validamos no DTO de registro.
        public DateTime CreatedAt { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve ser um endereço de e-mail válido.")]
        [StringLength(254, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O campo {0} deve estar no formato CPF válido (XXX.XXX.XXX-XX).")]
        public string Cpf { get; set; }

        //Deveria ser um enum
        [StringLength(50, ErrorMessage = "O Status deve ter no maximo 50 caracteres.")]
        public string? Status { get; set; }  

    }
}