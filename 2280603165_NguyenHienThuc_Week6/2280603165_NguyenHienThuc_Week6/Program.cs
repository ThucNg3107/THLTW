using _2280603165_NguyenHienThuc_Week6.Models;
using _2280603165_NguyenHienThuc_Week6.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load cấu hình từ appsettings.json
var configuration = builder.Configuration;

// Đăng ký DbContext với SQL Server
builder.Services.AddDbContext<ThucDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ThucDbContext")));

// Đăng ký Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Đăng ký Controller
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Định tuyến (Route)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
