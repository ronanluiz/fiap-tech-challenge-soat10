namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public interface IIdentifyUseCase
    {
        Task<IdentifyResponse?> ExecuteCustomerSearchByCpfAsync(string cpf);
    }
}