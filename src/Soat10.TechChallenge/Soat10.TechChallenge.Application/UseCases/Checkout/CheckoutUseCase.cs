using FluentValidation;
using FluentValidation.Results;
using Soat10.TechChallenge.Application.DTOs;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Services;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.UseCases.Checkout
{
    public class CheckoutUseCase(IPaymentService paymentService,
        IOrderRepository orderRepository,
        IPaymentRepository paymentRepository) : ICheckoutUseCase
    {
        private readonly IPaymentService _paymentService = paymentService;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IValidator<CheckoutRequest> _validator;

        public async Task ExecuteOrderCheckoutAsync(CheckoutRequest checkoutRequest)
        {
            ValidationResult result = _validator.Validate(checkoutRequest);

            if (!result.IsValid)
            {
                throw new Exceptions.ValidationException(result.Errors.Select(e => e.ErrorMessage));
            }

            PaymentResponseDto paymentResponse = await _paymentService.ProcessPaymentAsync(checkoutRequest.OrderNumber, checkoutRequest.PaymentQrCode);
            if (paymentResponse.IsSuccess)
            {
                Order order = await _orderRepository.GetByIdAsync(checkoutRequest.OrderNumber);
                order.ChangeStatus(OrderStatus.Paid);
                await _orderRepository.UpdateAsync(order);

                Payment payment = new(paymentResponse.PaymentId, order.Id, order.Amount);
                await _paymentRepository.AddAsync(payment);
            }
            else
            {
                throw new NotAllowedException(paymentResponse.MessageResult);
            }
        }
    }
}
