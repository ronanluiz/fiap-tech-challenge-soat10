using Soat10.TechChallenge.Application.UseCases.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.GetPreparingOrders
{
    public interface IGetPreparingOrders
    {
        Task<IEnumerable<GetOrdersResponse>> GetOrdersAsync();
    }
}
