using CodePatterns.Data;
using CodePatterns.Data.Models;
using CodePatterns.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodePatterns.Api.Controllers
{
    /// <summary>
    /// SRP: ProductsController hanterar bara request som gäller att hämta alla produkter.
    /// 
    /// OCP: ProductsController kan utökas med funktionalitet/fler requests utan att den
    /// existerande koden slutar fungera.
    /// 
    /// LSP: Det fanns inget behov att jobba med arv annat än ControllerBase som
    /// är default i våra .NET api controllers.
    /// 
    /// ISP: Inte heller något behov av denna princip här.
    /// 
    /// DIP: Vår controller har inget konkret beroende utan beroendet är abstrakt 
    /// genom interfaces och dependency injection för att nå services i klassbibliotek Data.
    /// </summary>

    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductsService _get;
        public ProductsController(IGetProductsService get)
        {
            _get = get;
        }

        [HttpGet]
        public async Task<IEnumerable<IProductModel>> GetProductsAsync() =>
            await _get.GetProductsAsync();
    }
}