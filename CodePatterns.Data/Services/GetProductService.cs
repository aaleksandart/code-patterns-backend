using CodePatterns.Data.Context;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Models.Entities;
using CodePatterns.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CodePatterns.Data.Services
{
    /// <summary>
    /// SRP: GetProductService har ett jobb, att hämta enstaka produkter.
    /// 
    /// OCP: Vi kan utöka den här klassen utan att ändra på existerande kod.
    /// Mitt mål var en generell hämtning av en specifik produkt, detta fungerade
    /// men bröt dessvärre mot OCP då den skulle behöva modifieras med en switch
    /// sats varje gång en ny produkt typ lades till.
    /// Därav specifika metoder för varje produkttyp.
    /// 
    /// ISP: Vi använder IGetProductService så att andra klasser bara har tillgång
    /// till det som behövs för att hämta en produkt.
    /// 
    /// DIP: Vår service har inget konkret beroende utan beroendet är abstrakt 
    /// genom interfaces och dependency injection för att nå factories och skapa objekt.
    /// 
    /// DRY: Vi använder en privat metod för att hämta en produkt från databasen oavsett typ.
    /// </summary>
    public interface IGetProductService
    {
        Task<IProductModel> GetShoeAsync(int id);
        Task<IProductModel> GetDressAsync(int id);
    }
    public class GetProductService : IGetProductService
    {
        private readonly SqlContext _db;
        private readonly IProductModelFactory _modelFactory;
        private readonly IGenericFactory _genericFactory;
        public GetProductService(SqlContext db, IProductModelFactory modelFactory, IGenericFactory genericFactory)
        {
            _db = db;
            _modelFactory = modelFactory;
            _genericFactory = genericFactory;
        }

        private async Task<ProductDetailEntity?> GetProductFromDB(int id)
        {
            var product = _genericFactory.CreateGeneric<ProductDetailEntity>();
            return await _db.ProductDetail.Include(x => x.Product.ProductType).Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }
        public async Task<IProductModel> GetShoeAsync(int id)
        {
            try
            {
                var shoe = await GetProductFromDB(id);
                if (shoe != null)
                    return _modelFactory.CreateShoeModel(shoe);

                return _genericFactory.CreateGeneric<ProductModel>();
            }
            catch { return _genericFactory.CreateGeneric<ProductModel>(); }
        }
        public async Task<IProductModel> GetDressAsync(int id)
        {
            try
            {
                var dress = await GetProductFromDB(id);
                if (dress != null)
                    return _modelFactory.CreateDressModel(dress);

                return _genericFactory.CreateGeneric<ProductModel>();
            }
            catch { return _genericFactory.CreateGeneric<ProductModel>(); }
        }
    }

}

