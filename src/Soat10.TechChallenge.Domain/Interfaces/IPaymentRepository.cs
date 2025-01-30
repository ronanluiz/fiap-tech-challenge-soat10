using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Domain.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> AddAsync(Payment payment);
    }
}
