using Soat10.TechChallenge.Domain.Base;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Product : Entity<int>
    {
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
