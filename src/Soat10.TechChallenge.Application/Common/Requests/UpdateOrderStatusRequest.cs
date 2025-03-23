using Soat10.TechChallenge.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class UpdateOrderStatusRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EnumDataType(typeof(OrderTransitionStatus), ErrorMessage = "O valor do campo {0} é inválido.")]
        public OrderTransitionStatus NewStatus { get; set; }
    }
}