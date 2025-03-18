using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Application.Common.Interfaces
{
    public interface IDataRepository
    {
        #region Costumer's interfaces
        Task<int> AddCustomerAsync(CustomerDao customer);
        Task<CustomerDao> GetCustomerAsync(string cpf);
        #endregion 

        #region Order's Interfaces
        Task<OrderDao> GetOrderByIdAsync(int id);
        Task UpdateOrderAsync(OrderDao order);
        Task<IEnumerable<OrderDao>> GetAllOrdersAsync();
        Task<OrderDao> GetOrderByNumber(int orderNumber);
        #endregion

        #region Payment's Interfaces
        Task<int> AddPaymentAsync(PaymentDao payment);
        Task<PaymentDao> GetPaymentByOrderIdAsync(int orderId);
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
    }
}
