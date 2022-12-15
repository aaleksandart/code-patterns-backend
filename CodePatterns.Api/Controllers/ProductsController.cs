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
        // Jag valde att samla alla requests som gäller produkter i en controller
        // jag hade troligtvis gjort annorlunda om jag hade fler produkter.
        // Eftersom controllern bara hanterar produkter så följer den fortfarnade SRP.

        private readonly IDataLayer _data;
        public ProductsController(IDataLayer data)
        {
            _data = data;
        }

        #region Get requests
        [HttpGet]
        public async Task<IEnumerable<IProductModel>> GetProductsAsync() =>
            await _data.GetProductsAsync();

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetProductAsync(int id) =>
            await _data.GetProductAsync(id);
        #endregion

        #region Post requests
        
        [HttpPost("shoe")]
        public async Task<IActionResult> CreateShoeAsync(ShoeModel product) =>
            await _data.CreateProductAsync(product);

        [HttpPost("dress")]
        public async Task<IActionResult> CreateDressAsync(DressModel product) =>
            await _data.CreateProductAsync(product);
        #endregion

        #region Update requests
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, IProductModel productUpdate) =>
            await _data.UpdateProductAsync();
        #endregion

        #region Delete requests
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id) =>
            await _data.DeleteProductAsync();
        #endregion
    }
}