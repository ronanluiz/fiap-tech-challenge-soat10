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
        
        #region Costumer's Repository

        public async Task<int> AddCustomerAsync(CustomerDao customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        public Task<CustomerDao> GetCustomerAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDao> GetCustomerByIdAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }
        #endregion

        #region Payment's Repository
        public async Task<int> AddPaymentAsync(PaymentDao payment)
        {
            return await _paymentRepository.AddAsync(payment);
        }

        public async Task<PaymentDao> GetPaymentByOrderAsync(Guid orderId)
        {
            return await _paymentRepository.GetByOrderAsync(orderId);
        }

        public async Task UpdatePaymentAsync(PaymentDao paymentDao)
        {
            await _paymentRepository.UpdateAsync(paymentDao);
        }

        #endregion

        #region Order's Repository
        public async Task<IEnumerable<OrderDao>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<OrderDao> GetOrderByIdAsync(Guid id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<OrderDao> GetOrderByNumberAsync(int orderNumber)
        {
            return await _orderRepository.GetOrderByNumber(orderNumber);
        }

        public async Task<OrderDao> AddOrderAsync(OrderDao order)
        {
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task UpdateOrderAsync(OrderDao order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task UpdateOrderStatusAsync(OrderDao order)
        {
            await _orderRepository.UpdateOrderStatusAsync(order);
        }
        #endregion

        #region Product's Repository
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

        public Task<IEnumerable<ProductDao>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDao>> GetAvailableProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductDao product)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddProductAsync(ProductDao product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(ProductDao product)
        {
            throw new NotImplementedException();
        }
        #endregion

        

        #region Cart
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
        #endregion

        public async Task<IEnumerable<OrderDao>> GetOpenOrdersAsync()
        {
            IEnumerable<OrderDao> orders = await _orderRepository.GetAllOpen();
            return orders;
        }
    }
}
