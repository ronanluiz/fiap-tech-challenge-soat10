using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class GetOrderPaymentStatusUseCase
    {
        private readonly OrderGateway _orderGateway;

        public GetOrderPaymentStatusUseCase(OrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public static GetOrderPaymentStatusUseCase Build(OrderGateway orderGateway)
        {
            return new GetOrderPaymentStatusUseCase(orderGateway);
        }

        public async Task<Order> ExecuteAsync(int orderNumber)
        {
            return await _orderGateway.GetOrderByNumber(orderNumber);
        }
    }
}
