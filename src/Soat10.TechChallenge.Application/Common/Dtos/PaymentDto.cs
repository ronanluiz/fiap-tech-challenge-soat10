using Soat10.TechChallenge.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class PaymentDto
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public string Status { get; set; }
        public string DetailedStatus { get; set; }
    }
}
