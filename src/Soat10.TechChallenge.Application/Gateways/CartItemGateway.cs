using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class CartItemGateway
    {
        private readonly IDataRepository _dataRepository;

        public CartItemGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task CreateAsync(CartItem cartItem)
        {
            CartItemDao cartItemDao = MapperDao.Map(cartItem);
            cartItemDao.Product = null;
            await _dataRepository.AddCartItemAsync(cartItemDao);
        }
    }
}
