namespace Soat10.TechChallenge.Application.DTOs
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }
    }
}
