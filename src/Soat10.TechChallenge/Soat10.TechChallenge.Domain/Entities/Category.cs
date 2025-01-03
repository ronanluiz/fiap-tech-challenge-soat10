using Soat10.TechChallenge.Domain.Base;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public Category() : base(Guid.NewGuid()) 
        { 
        }
    }
}
