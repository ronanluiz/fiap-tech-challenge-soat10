
using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Cart : Entity<Guid>
    {
        public Cart() : base(Guid.NewGuid()) 
        {
            Status = CartStatus.Created;
            CreatedAt = DateTime.Now;
        }

        public Cart(Customer customer) : this()
        {
            Customer = customer;
            CustomerId = customer.Id;
        }

        public Cart(Guid id, Customer customer, List<CartItem> items, CartStatus status, DateTime createdDate) : base(id)
        {   
            Customer = customer;
            Status = status;
            Items = items;
            CreatedAt = createdDate;
        }

        public CartStatus Status { get; private set; }
        public virtual Customer Customer { get; private set; }
        public Guid CustomerId { get; private set; }
        public virtual ICollection<CartItem> Items { get; private set; } = [];
        public DateTime CreatedAt { get; private set; }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }

        public void ChangeStatus(CartStatus status)
        {
            Status = status;
        }        
    }
}