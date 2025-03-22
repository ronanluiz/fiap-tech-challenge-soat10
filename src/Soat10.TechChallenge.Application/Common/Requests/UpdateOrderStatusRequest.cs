using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class UpdateOrderStatusRequest
    {
        public OrderTransitionStatus NewStatus { get; set; }
    }

}