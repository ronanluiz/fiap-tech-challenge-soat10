namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class CustomerDao
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string Status { get; set; }
    }
}
