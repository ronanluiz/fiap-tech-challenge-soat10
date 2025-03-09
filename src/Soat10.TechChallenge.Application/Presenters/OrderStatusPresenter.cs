using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Presenters
{
    internal class OrderStatusPresenter
    {
        public static IEnumerable<OrderStatusDto> Build(IEnumerable<Order> orders)
        {
            IList<OrderStatusDto> orderStatusDtos = orders
                                        .Select(o => new OrderStatusDto(o.Id, o.Status))
                                        .ToList();

            return orderStatusDtos;
        }
    }
}