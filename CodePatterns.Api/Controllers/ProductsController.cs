using CodePatterns.Data;
using CodePatterns.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodePatterns.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataLayer _data;
        public ProductsController(IDataLayer data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<IEnumerable<IProductModel>> GetProductsAsync() =>
            await _data.GetProductsAsync();

        [HttpGet("{category}")]
        public async Task<IEnumerable<IProductModel>> GetProductsByCategoryAsync(string category) =>
            await _data.GetProductsByCategoryAsync();

        [HttpGet("{id}")]
        public async Task<IProductModel> GetProductAsync(int id) =>
            await _data.GetProductAsync(id);

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ShoeModel shoe) =>
            await _data.CreateProductAsync(shoe);

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, IProductModel productUpdate) =>
            await _data.UpdateProductAsync();

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id) =>
            await _data.DeleteProductAsync();
    }
}
