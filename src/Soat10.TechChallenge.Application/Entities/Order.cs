using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Validators;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Order : Entity<Guid>
    {
        protected Order() : base(Guid.NewGuid()) { }

        public Order(Customer customer)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Customer = customer;
            CustomerId = Customer.Id;
            Status = OrderStatus.Requested;
        }

        public Order(Guid id, Customer customer, List<OrderItem> orderItems, int orderNumber) : base(id)
        {
            Customer = customer;
            CustomerId = customer.Id;
            Status = OrderStatus.Requested;
            Items = orderItems;
            OrderNumber = orderNumber;

            Validate();
        }

        public Order(Guid id, Customer customer, List<OrderItem> orderItems, OrderStatus status) : base(id)
        {
            Customer = customer;
            Status = status;
            Items = orderItems;

            Validate();
        }

        public Order(Guid id,
            OrderStatus status,
            Customer customer, 
            List<OrderItem> items,
            int orderNumber,
            DateTime createdAt) : base(id) 
        {
            Customer = customer;
            CustomerId = customer.Id;
            Status = status;
            Items = items;
            OrderNumber = orderNumber;
            CreatedAt = createdAt;

            Validate();
        }

        public Order(Guid id, OrderStatus status) : base(id)
        {
            Status = status;

            Validate();
        }

        public OrderStatus Status { get; private set; }
        public virtual Customer Customer { get; private set; }
        public Guid CustomerId { get; private set; }
        public int OrderNumber { get; private set; }
        public string OrderNumberToDisplay => OrderNumber.ToString().PadLeft(7, '0');
        public virtual ICollection<OrderItem> Items { get; private set; } = [];
        public decimal TotalAmount => Items.Sum(i => i.TotalAmont);
        public DateTime CreatedAt { get; private set; }

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