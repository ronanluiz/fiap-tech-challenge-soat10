using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class IdentifyRequest
    {
        // Opção 1: CPF com formatação (XXX.XXX.XXX-XX) - Recomendado
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O campo {0} deve estar no formato CPF válido (XXX.XXX.XXX-XX).")]
        public string Cpf { get; set; }
    }
}