namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public interface ICustomerRegistrationUseCase
    {
        Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRequest);
    }
}