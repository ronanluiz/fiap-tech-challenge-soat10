using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Presenters
{
    public class IdentityPresenter
    {
        public static IdentifyResponse Build(Customer customer)
        {
            return new IdentifyResponse()
            {
                Cpf = customer.Cpf.Number,
                Email = customer.Email.Address,
                CreatedAt = customer.CreatedAt,
                Id = customer.Id,
                Name = customer.Name,
                Status = customer.Status
            };
        }
    }
}
