using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class CartGateway
    {
        private readonly IDataRepository _dataRepository;        

        public CartGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task CreateAsync(Cart cart)
        {
            CartDao cartDao = MapperDao.Map(cart);
            CartDao cartCreated = await _dataRepository.AddCartAsync(cartDao);
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            CartDao cartDao = await _dataRepository.GetCartByIdAsync(id);

            Cart cart = MapperEntity.MapToEntity(cartDao);

            return cart;
        }
    }
}
