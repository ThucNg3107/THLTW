﻿using _2280603165_NguyenHienThuc_Week3.Extensions;
using _2280603165_NguyenHienThuc_Week3.Models;
using _2280603165_NguyenHienThuc_Week3.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _2280603165_NguyenHienThuc_Week3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartController(ApplicationDbContext context,
UserManager<ApplicationUser> userManager, IProductRepository
productRepository)
        {
            _productRepository = productRepository;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Checkout()
        {
            return View(new Orders());
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Orders order)
        {
            var cart =
           HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                // Xử lý giỏ hàng trống...
                return RedirectToAction("Index");
            }
            var user = await _userManager.GetUserAsync(User);
            order.UserId = user.Id;
            order.OrderDate = DateTime.UtcNow;
            order.TotalPrice = cart.Items.Sum(i => i.Price * i.Quantity);
            order.OrderDetails = cart.Items.Select(i => new OrderDetail
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("Cart");
            return View("OrderCompleted", order.Id); // Trang xác nhận hoàn thành đơn hàng
 }

        /*public ShoppingCartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }*/
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            // Giả sử bạn có phương thức lấy thông tin sản phẩm từ productId
            var product = await GetProductFromDatabase(productId);
            var cartItem = new CartItem
            {
                ProductId = productId,
                Name = product.Name,
                Price = product.Price,
                Quantity = quantity
            };
            var cart =
           HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new
           ShoppingCart();
            cart.AddItem(cartItem);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var cart =
           HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new
           ShoppingCart();
            return View(cart);
        }
        public IActionResult CheckoutSingle(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart == null || cart.Items.Count == 0)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }

            var selectedItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (selectedItem == null)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }

            // Chuyển đến trang Checkout với sản phẩm đã chọn
            return View("Checkout", selectedItem);
        }
        // Các actions khác...
        private async Task<Product> GetProductFromDatabase(int productId)
        {
            // Truy vấn cơ sở dữ liệu để lấy thông tin sản phẩm
            var product = await _productRepository.GetByIdAsync(productId);
            return product;
        }
        public IActionResult RemoveFromCart(int productId)
        {
            var cart =
           HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart is not null)
            {
                cart.RemoveItem(productId);
                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}
