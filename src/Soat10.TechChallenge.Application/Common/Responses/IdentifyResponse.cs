namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class IdentifyResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }

    }
}
