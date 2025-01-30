namespace Soat10.TechChallenge.Application.UseCases.Identify
{
    public interface IIdentifyUseCase
    {
        Task<IdentifyResponse?> ExecuteSearchAsync(string cpf);
    }
}