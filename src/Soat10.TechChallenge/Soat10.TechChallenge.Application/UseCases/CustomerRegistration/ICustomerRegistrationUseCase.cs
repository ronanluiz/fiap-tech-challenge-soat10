using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public interface ICustomerRegistrationUseCase
    {
        Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRegistrationRequest);
    }
}
