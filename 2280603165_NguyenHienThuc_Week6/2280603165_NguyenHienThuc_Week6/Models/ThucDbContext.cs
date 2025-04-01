using _2280603165_NguyenHienThuc_Week6.Models;
using Microsoft.EntityFrameworkCore;
namespace _2280603165_NguyenHienThuc_Week6.Models
{
    public class ThucDbContext : DbContext
    {
        public ThucDbContext(DbContextOptions<ThucDbContext> options) : base(options)
        {
        } 
        public DbSet<Product> Products { get; set; }
       
    }
}
