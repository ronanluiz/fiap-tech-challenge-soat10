using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class PaymentController
    {
        private readonly IDataRepository _dataRepository;

        public PaymentController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        private static PaymentController Build(IDataRepository dataRepository)
        {
            return new PaymentController(dataRepository);
        }
    }
}
