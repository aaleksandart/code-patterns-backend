using CodePatterns.Data;
using CodePatterns.Data.Models;
using CodePatterns.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodePatterns.Api.Controllers
{
    /// <summary>
    /// SRP: DressController hanterar bara request som gäller produkter av typen dress.
    /// 
    /// OCP: DressController kan utökas med funktionalitet/fler requests utan att den
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

    [Route("api/dress")]
    [ApiController]
    public class DressController : ControllerBase
    {
        private readonly IGetProductService _get;
        private readonly ICreateProductService _create;
        public DressController(IGetProductService get, ICreateProductService create)
        {
            _get = get;
            _create = create;
        }

        [HttpGet("{id}")]
        public async Task<IProductModel> GetDressAsync(int id) =>
            await _get.GetDressAsync(id);

        [HttpPost]
        public async Task<IActionResult> CreateDressAsync(DressModel product) =>
            await _create.CreateDressAsync(product) == true ? Created("", null) : StatusCode(500);
    }
}
