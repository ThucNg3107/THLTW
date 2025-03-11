using System.Collections.Generic;
using System.Linq;
using NguyenHienThuc_2280603165.Models;
namespace NguyenHienThuc_2280603165.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public MockProductRepository()
        {
            // Tạo một số dữ liệu mẫu
            _products = new List<Product>
            {
                 new Product { Id = 1, Name = "Laptop", Price = 1000, Description
                = "A high-end laptop"},
            // Thêm các sản phẩm khác
        };
     }
             public IEnumerable<Product> GetAll()
            {
                return _products;
            }
            public Product GetById(int id)
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
            public void Add(Product product)
            {
                product.Id = _products.Max(p => p.Id) + 1;
                _products.Add(product);
            }
            public void Delete(int id)
            {
                throw new NotImplementedException();
            }
            public void Update(Product product)
            {
                throw new NotImplementedException();
            }
    }
}
