namespace Soat10.TechChallenge.Application.UseCases.Checkout
{
    public interface ICheckoutUseCase
    {
        Task ExecuteOrderCheckoutAsync(CheckoutRequest checkoutRequest);
    }
}
