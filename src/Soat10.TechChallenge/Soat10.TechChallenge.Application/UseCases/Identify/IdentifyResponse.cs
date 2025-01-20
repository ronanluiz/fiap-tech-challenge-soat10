namespace Soat10.TechChallenge.Application.UseCases.Identify
{
    public class IdentifyResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }

    }
}
