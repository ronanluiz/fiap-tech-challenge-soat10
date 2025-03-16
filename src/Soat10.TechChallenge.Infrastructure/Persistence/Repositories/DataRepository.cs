using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    internal class DataRepository : IDataRepository
    {
        private readonly CustomerRepository _customerRepository;
        private readonly PaymentRepository _paymentRepository;
        private readonly OrderRepository _orderRepository;
        private readonly OrderProductRepository _orderProductRepository;

        public DataRepository(CustomerRepository customerRepository, 
            PaymentRepository paymentRepository,
            OrderRepository orderRepository,
            OrderProductRepository orderProductRepository)
        {
            _customerRepository = customerRepository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }
        public async Task<int> AddCustomerAsync(CustomerDao customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        public async Task<int> AddPaymentAsync(PaymentDao payment)
        {
            return await _paymentRepository.AddAsync(payment);
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

        public async Task<IEnumerable<OrderProductDao>> GetOrdersFromViewAsync()
        {
            return await _orderProductRepository.GetOrdersFromViewAsync();
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

        public async Task<OrderDao> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public Task<ProductDao> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
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
    }
}
