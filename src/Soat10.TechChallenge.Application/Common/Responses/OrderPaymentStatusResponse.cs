using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class OrderPaymentStatusResponse
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string StatusPayment { get; set; }
        public string DetailedStatusPayment { get; set; }
        public decimal OrderValue { get; set; }
        public string CustomerName { get; set; }
    }
}
