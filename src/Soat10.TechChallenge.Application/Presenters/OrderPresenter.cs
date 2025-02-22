using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Presenters
{
    public class OrderPresenter
    {
        public static IEnumerable<OrderDto> Build(IEnumerable<Order> orders)
        {
            IList<OrderDto> orderDtos = orders
                                        .Select(o => Mapper.MapToDto(o))
                                        .ToList();

            return orderDtos;
        }
    }
}
