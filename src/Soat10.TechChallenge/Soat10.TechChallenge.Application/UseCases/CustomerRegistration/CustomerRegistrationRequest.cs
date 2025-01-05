using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public class CustomerRegistrationRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
