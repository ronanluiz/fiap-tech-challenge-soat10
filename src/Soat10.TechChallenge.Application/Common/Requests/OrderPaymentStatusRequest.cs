using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class OrderPaymentStatusRequest
    {
        [Required(ErrorMessage = "O número do pedido é obrigatório.")]
        [Range(1, 1000, ErrorMessage = "Número do pedido inválido.")]
        public int OrderNumber { get; set; }
    }
}
