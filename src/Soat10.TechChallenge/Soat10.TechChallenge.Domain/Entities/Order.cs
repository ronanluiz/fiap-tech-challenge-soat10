using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Domain.Exceptions;
using Soat10.TechChallenge.Domain.Validators;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Order : Entity<int>
    {
        protected Order() : base(default) { }

        public Order(int id, Customer customer, List<OrderItem> orderItems) : base(id)
        {
            Customer = customer;
            Status = OrderStatus.Requested;
            Items = orderItems;

            Validate();
        }

        public OrderStatus Status { get; private set; }
        public Customer Customer { get; private set; }
        public int CustomerId { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public decimal Amount { get; private set; }

        private static readonly OrderValidator Validator = new();

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void ChangeStatus(OrderStatus orderStatus) 
        {
            Status = orderStatus;
        }

        private void Validate()
        {
            var result = Validator.Validate(this);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage);
                throw new DomainValidationException(errors);
            }
        }
    }
}