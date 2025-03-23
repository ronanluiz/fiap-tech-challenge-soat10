using Soat10.TechChallenge.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }

        public virtual CustomerDto Customer { get; set; }

        public virtual PaymentDto Payment { get; set; }

        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser maior que zero.")]
        public int OrderNumber { get; set; }

        public virtual ICollection<OrderItemDto> Items { get; set; } = [];

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "O campo {0} deve ser maior ou igual a zero.")]
        public decimal Amount { get; set; }
    }
}