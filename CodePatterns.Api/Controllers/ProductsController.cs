using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodePatterns.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetProductsAsync()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string GetProductAsync(int id)
        {
            return "value";
        }

        [HttpPost]
        public void CreateProductAsync([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void UpdateProductAsync(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteProductAsync(int id)
        {
        }
    }
}
