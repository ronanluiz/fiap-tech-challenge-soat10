using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Application.Common.Interfaces
{
    public interface IDataRepository
    {
        #region Costumer's interfaces
        Task<int> AddCustomerAsync(CustomerDao customer);
        Task<CustomerDao> GetCustomerAsync(string cpf);
        Task<CustomerDao> GetCustomerByIdAsync(Guid id);
        #endregion

        #region Order's Interfaces
        Task<OrderDao> GetOrderByIdAsync(Guid id);        
        Task UpdateOrderAsync(OrderDao order);
        Task<OrderDao> AddOrderAsync(OrderDao order);
        Task<IEnumerable<OrderDao>> GetAllOrdersAsync();
        Task<OrderDao> GetOrderByNumberAsync(int orderNumber);
        Task<IEnumerable<OrderDao>> GetOpenOrdersAsync();
        Task UpdateOrderStatusAsync(OrderDao order);
        #endregion

        #region Payment's Interfaces
        Task<int> AddPaymentAsync(PaymentDao payment);
        Task<PaymentDao> GetPaymentByOrderAsync(Guid orderId);
        Task UpdatePaymentAsync(PaymentDao paymentDao);
        #endregion

        #region Product's Interfaces
        Task<ProductDao> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDao>> GetAllProductsAsync();
        Task<int> AddProductAsync(ProductDao product);
        Task UpdateProductAsync(ProductDao product);
        Task DeleteProductAsync(ProductDao product);
        Task<IEnumerable<ProductDao>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductDao>> GetProductsByStatusAsync(string status);
        Task<IEnumerable<ProductDao>> GetAvailableProductsAsync();
        #endregion

        #region Cart
        Task<CartDao> GetCartByIdAsync(Guid id);
        Task<CartDao> AddCartAsync(CartDao cart);
        Task<CartItemDao> AddCartItemAsync(CartItemDao cartItem);
        #endregion

        
    }
}
