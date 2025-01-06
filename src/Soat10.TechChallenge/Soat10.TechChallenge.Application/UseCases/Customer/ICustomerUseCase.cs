namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public interface ICustomerUseCase
    {
        Task ExecuteCustomerRegistrationAsync(CustomerRequest customerRequest);
    }
}
