using _2280603165_NguyenHienThuc_Week6.Models;
using _2280603165_NguyenHienThuc_Week6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _2280603165_NguyenHienThuc_Week6.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductApiController> _logger;

        public ProductApiController(IProductRepository productRepository, ILogger<ProductApiController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                _logger.LogInformation("Fetching all products...");
                var products = await _productRepository.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching products");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching product with ID: {id}");
                var product = await _productRepository.GetProductByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with ID: {id} not found");
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching product with ID: {id}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    _logger.LogWarning("Received null product in AddProduct");
                    return BadRequest("Product cannot be null");
                }
                _logger.LogInformation($"Adding new product: {product.Name}");
                await _productRepository.AddProductAsync(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    _logger.LogWarning($"ID mismatch: URL ID ({id}) != Product ID ({product.Id})");
                    return BadRequest("Product ID mismatch");
                }
                _logger.LogInformation($"Updating product with ID: {id}");
                await _productRepository.UpdateProductAsync(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating product with ID: {id}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting product with ID: {id}");
                await _productRepository.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product with ID: {id}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}