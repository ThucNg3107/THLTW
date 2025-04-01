using _2280603165_NguyenHienThuc_Week6.Models;

namespace _2280603165_NguyenHienThuc_Week6.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

    }
}
