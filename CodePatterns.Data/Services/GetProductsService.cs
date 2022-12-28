using CodePatterns.Data.Context;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Services
{
    /// <summary>
    /// SRP: GetProductsService har ett jobb, att hämta alla produkter oavsett typ.
    /// 
    /// OCP: Vi kan utöka den här klassen utan att ändra på existerande kod.
    /// 
    /// ISP: Vi använder IGetProductsService så att andra klasser bara har tillgång
    /// till det som behövs för att hämta alla produkter.
    /// 
    /// DIP: Vår service har inget konkret beroende utan beroendet är abstrakt 
    /// genom interfaces och dependency injection för att nå factories och skapa objekt.
    public interface IGetProductsService
    {
        Task<IEnumerable<IProductModel>> GetProductsAsync();
    }
    public class GetProductsService : IGetProductsService
    {
        private readonly SqlContext _db;
        private readonly IProductModelFactory _modelFactory;
        private readonly IGenericFactory _genericFactory;
        public GetProductsService(SqlContext db, IProductModelFactory modelFactory, IGenericFactory genericFactory)
        {
            _db = db;
            _modelFactory = modelFactory;
            _genericFactory = genericFactory;
        }
        public async Task<IEnumerable<IProductModel>> GetProductsAsync()
        {
            try
            {
                var modelList = _genericFactory.CreateGeneric<List<IProductModel>>();
                foreach (var product in await _db.ProductDetail.Include(x => x.Product.ProductType).ToListAsync())
                {
                    modelList.Add(_modelFactory.CreateBaseProduct(product));
                }
                return modelList;
            }
            catch { return _genericFactory.CreateGeneric<List<IProductModel>>(); }
        }
    }
}
