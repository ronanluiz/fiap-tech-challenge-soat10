using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Customer : Entity<int>
    {
        protected Customer() : base(default) { }

        public Customer(int id, Email email) : base(id)
        {
            Email = email;
        }

        public Email Email { get; }
    }
}