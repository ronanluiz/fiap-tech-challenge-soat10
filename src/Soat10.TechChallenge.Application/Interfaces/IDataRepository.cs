using Soat10.TechChallenge.Application.Daos;

namespace Soat10.TechChallenge.Application.Interfaces
{
    public interface IDataRepository
    {
        Task<int> AddCustomerAsync(CustomerDao customer);
        Task<CustomerDao> GetCustomerAsync(string cpf);
        Task<OrderDao> GetOrderByIdAsync(int id);
        Task UpdateOrderAsync(OrderDao order);
        Task<IEnumerable<OrderDao>> GetAllOrdersAsync();
        Task<int> AddPaymentAsync(PaymentDao payment);
        Task<ProductDao> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDao>> GetAllProductsAsync();
        Task<int> AddProductAsync(ProductDao product);
        Task UpdateProductAsync(ProductDao product);
        Task DeleteProductAsync(ProductDao product);
        Task<IEnumerable<ProductDao>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductDao>> GetProductsByStatusAsync(string status);
        Task<IEnumerable<ProductDao>> GetAvailableProductsAsync();
    }
}
