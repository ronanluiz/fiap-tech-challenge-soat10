using Soat10.TechChallenge.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Common.Responses
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryEnum ProductCategory { get; set; }
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; }
        public TimeSpan TimeToPrepare { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
