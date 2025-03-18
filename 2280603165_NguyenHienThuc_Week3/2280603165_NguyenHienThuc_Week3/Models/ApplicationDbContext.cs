using _2280603165_NguyenHienThuc_Week3.Models;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
   options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed dữ liệu mẫu cho Category
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Điện tử" },
            new Category { Id = 2, Name = "Gia dụng" },
            new Category { Id = 3, Name = "Thời trang" }
        );
    }
}