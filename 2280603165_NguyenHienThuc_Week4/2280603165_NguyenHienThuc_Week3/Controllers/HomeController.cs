using System.Diagnostics;
using _2280603165_NguyenHienThuc_Week3.Models;
using _2280603165_NguyenHienThuc_Week3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _2280603165_NguyenHienThuc_Week3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }




        

        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult lienhe()
        {
            return View();
        }
    }
}
