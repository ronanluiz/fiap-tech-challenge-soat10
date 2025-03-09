using Soat10.TechChallenge.Application.Common.Dtos;

namespace Soat10.TechChallenge.Application.Presenters
{
    internal class OrderStatusPresenter
    {
        public static IEnumerable<OrderStatusDto> Build(IEnumerable<OrderStatusDto> orders)
        {
            IList<OrderStatusDto> orderStatusDtos = orders
                                        .Select(o => new OrderStatusDto(o.Id, o.Status))
                                        .ToList();

            return orderStatusDtos;
        }
    }
}