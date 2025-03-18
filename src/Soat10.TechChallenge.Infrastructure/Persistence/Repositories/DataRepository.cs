using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly CustomerRepository _customerRepository;
        private readonly PaymentRepository _paymentRepository;
        private readonly OrderRepository _orderRepository;
        private readonly CartRepository _cartRepository;
        private readonly ProductRepository _productRepository;

        public DataRepository(CustomerRepository customerRepository, 
            PaymentRepository paymentRepository,
            OrderRepository orderRepository,
            CartRepository cartRepository,
            ProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }        

        public async Task<int> AddCustomerAsync(CustomerDao customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        public async Task<int> AddPaymentAsync(PaymentDao payment)
        {
            return await _paymentRepository.AddAsync(payment);
        }

        public async Task<CartDao> AddCartAsync(CartDao cart)
        {
            await _cartRepository.AddAsync(cart);
            return cart;
        }

        public async Task<CartDao> GetCartByIdAsync(Guid id)
        {
            return await _cartRepository.GetByIdAsync(id);
        }

        public async Task<CartItemDao> AddCartItemAsync(CartItemDao cartItem)
        {
            await _cartRepository.AddAsync(cartItem);
            return cartItem;
        }

        public Task<int> AddProductAsync(ProductDao product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(ProductDao product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDao>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public Task<IEnumerable<ProductDao>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDao>> GetAvailableProductsAsync()
        {
            throw new NotImplementedException();
        }        

        public Task<CustomerDao> GetCustomerAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDao> GetCustomerByIdAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<OrderDao> GetOrderByIdAsync(Guid id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<ProductDao> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<ProductDao>> GetProductsByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDao>> GetProductsByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderAsync(OrderDao order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public Task UpdateProductAsync(ProductDao product)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDao> AddOrderAsync(OrderDao order)
        {
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<PaymentDao> GetPaymentByOrder(Guid orderId)
        {
            return await _paymentRepository.GetByOrder(orderId);
        }

        public async Task UpdatePaymentAsync(PaymentDao paymentDao)
        {
            await _paymentRepository.UpdateAsync(paymentDao);
        }
    }
}
