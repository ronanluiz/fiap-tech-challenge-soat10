using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Customer : Entity<int>
    {
        protected Customer() : base(default) { }

        public Customer(int id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
    }
}