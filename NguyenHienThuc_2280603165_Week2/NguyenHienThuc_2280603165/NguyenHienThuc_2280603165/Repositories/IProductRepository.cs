using System.Collections.Generic;
using NguyenHienThuc_2280603165.Models;
namespace NguyenHienThuc_2280603165.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}
