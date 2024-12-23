using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Domain.Aggregates.CostumerAggregate
{
    public class Customer : AggregateRoot<int>
    {
        protected Customer() : base(default) { }

        public Customer(int id, Email email) : base(id)
        {
            Email = email;
        }

        public Email Email { get; }
    }
}
