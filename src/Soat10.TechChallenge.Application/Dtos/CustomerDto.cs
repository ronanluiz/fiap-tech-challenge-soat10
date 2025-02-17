using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }
    }
}
