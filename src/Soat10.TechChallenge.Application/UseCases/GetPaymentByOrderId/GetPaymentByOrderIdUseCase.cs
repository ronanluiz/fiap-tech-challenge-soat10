using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.GetPaymentByOrderId
{
    public class GetPaymentByOrderIdUseCase
    {
        private readonly PaymentGateway _paymentGeteway;

        private GetPaymentByOrderIdUseCase(PaymentGateway paymentGeteway)
        {
            _paymentGeteway = paymentGeteway;
        }

        public static GetPaymentByOrderIdUseCase Build(PaymentGateway paymentGeteway)
        {
            return new GetPaymentByOrderIdUseCase(paymentGeteway);
        }

        public async Task<Payment> ExecuteAsync(int orderId)
        {
            return await _paymentGeteway.GetPaymentByOrderIdAsync(orderId);
        }
    }
}
