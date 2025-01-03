using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Customer : Entity<int>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetEmail(Email email)
        {
            Email = email;
        }

        public void SetCpf(Cpf cpf)
        {
            Cpf = cpf;
        }
    }
}