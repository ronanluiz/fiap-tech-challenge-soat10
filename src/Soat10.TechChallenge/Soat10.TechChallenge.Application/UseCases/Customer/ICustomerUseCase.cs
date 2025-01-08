namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public interface ICustomerUseCase
    {
        Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRequest);
    }
}