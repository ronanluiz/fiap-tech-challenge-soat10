using Refit;
using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public interface IMercadoPagoApi
    {
        [Get("merchant_orders/{id}")]
        Task<ExternalOrderDao> GetOrder(int id);
    }
}
