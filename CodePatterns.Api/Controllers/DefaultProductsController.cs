using CodePatterns.Data;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Models;
using CodePatterns.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using System.Drawing;

namespace CodePatterns.Api.Controllers
{
    /// <summary>
    /// Den här controllern skapar default produkter för att ha något att testa med.
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultProductsController : ControllerBase
    {
        /// <summary>
        /// Controller endast för att skapa exempel produkter i en ny databas.
        /// </summary>
        private readonly ICreateProductService _create;
        private readonly IGenericFactory _factory;
        public DefaultProductsController(ICreateProductService create, IGenericFactory factory)
        {
            _create = create;
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDefaultProducts()
        {
            var resultList = _factory.CreateGeneric<List<bool>>();
            resultList.Add(await _create.CreateShoeAsync(SetDefaultShoe("Adidas Stan Smith", "Sneakers from Adidas.", 799, "white", "sneakers", true, false)));
            resultList.Add(await _create.CreateShoeAsync(SetDefaultShoe("Nike Air Force One", "Sneakers from Nike.", 1099, "black", "sneakers", true, false)));
            resultList.Add(await _create.CreateShoeAsync(SetDefaultShoe("Quicksilver Sand", "Flip flops from quicksilver.", 499, "blue", "flip-flop", false, false)));

            resultList.Add(await _create.CreateDressAsync(SetDefaultDress("Daydreamer dress", "Halter dress from Nelly.", 849, "yellow", "halter", "medium")));
            resultList.Add(await _create.CreateDressAsync(SetDefaultDress("Sparkles dress", "Cocktail dress from Zara.", 1299, "black", "cocktail", "short")));
            resultList.Add(await _create.CreateDressAsync(SetDefaultDress("Visions dress", "Maxi dress from HM.", 1549, "green", "maxi", "long")));

            foreach (var result in resultList)
            {
                if (result == false)
                    return StatusCode(500, "All items could not be created.");
            }

            return Created("", null);
        }
        #region SetDefaults
        private IShoeModel SetDefaultShoe(string name, string description, decimal price, string color, string shoeType, bool shoeLaces, bool heels)
        {
            var shoe = _factory.CreateGeneric<ShoeModel>();
            shoe.Name = name;
            shoe.Description = description;
            shoe.Price = price;
            shoe.Color = color;
            shoe.ShoeType = shoeType;
            shoe.ShoeLaces = shoeLaces;
            shoe.Heels = heels;
            return shoe;
        }
        private IDressModel SetDefaultDress(string name, string description, decimal price, string color, string dressType, string dressLength)
        {
            var dress = _factory.CreateGeneric<DressModel>();
            dress.Name = name;
            dress.Description = description;
            dress.Price = price;
            dress.Color = color;
            dress.DressType = dressType;
            dress.DressLength = dressLength;
            return dress;
        }
        #endregion
    }
}
