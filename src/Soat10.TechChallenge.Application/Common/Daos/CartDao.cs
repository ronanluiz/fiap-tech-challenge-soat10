using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class CartDao
    {
        public Guid Id { get; set; }
        public CartStatus Status { get; set; }
        public virtual CustomerDao Customer { get; set; }
        public int? CustomerId { get; set; }
        public virtual ICollection<CartItemDao> Items { get; set; } = [];
        public DateTime CreatedAt { get; set; }
    }
}
