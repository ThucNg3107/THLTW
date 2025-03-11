using NguyenHienThuc_2280603165.Models;

namespace NguyenHienThuc_2280603165.Repositories
{
    public interface ICategoryRepository 
    {
        IEnumerable<Category> GetAllCategories();
    }
}
