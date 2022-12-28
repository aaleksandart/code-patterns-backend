using CodePatterns.Data;
using CodePatterns.Data.Models;
using CodePatterns.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodePatterns.Api.Controllers
{
    /// <summary>
    /// SRP: ShoeController hanterar bara request som gäller produkter av typen shoe.
    /// 
    /// OCP: ShoeController kan utökas med funktionalitet/fler requests utan att den
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
    
    [Route("api/shoe")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IGetProductService _get;
        private readonly ICreateProductService _create;
        public ShoeController(IGetProductService get, ICreateProductService create)
        {
            _get = get;
            _create = create;
        }

        [HttpGet("{id}")]
        public async Task<IProductModel> GetShoeAsync(int id) =>
            await _get.GetShoeAsync(id);

        [HttpPost]
        public async Task<IActionResult> CreateShoeAsync(ShoeModel product) =>
            await _create.CreateShoeAsync(product) == true ? Created("", null) : StatusCode(500);
    }
}
