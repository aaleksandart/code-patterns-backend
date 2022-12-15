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

namespace CodePatterns.Data.Services
{
    //GetProductService hanterar alla get requests för produkter. Tanken var att separera
    //detta ännu mer i olika klasser men det blev bara mer rörigt än vad det hjälpte.
    //Alla metoder har en uppgift(SRP). 
    public interface IGetProductService
    {
        Task<IEnumerable<IProductModel>> GetProductsAsync();
        Task<IProductModel> GetProductAsync(int id);
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

        #region Get all
        public async Task<IEnumerable<IProductModel>> GetProductsAsync()
        {
            try
            {
                var modelList = _genericFactory.CreateGeneric<List<IProductModel>>();
                foreach (var product in await _db.ProductDetail.Include(x => x.Product.ProductType).ToListAsync())
                {
                    switch (product.Product.ProductType.Name)
                    {
                        case "shoe":
                            modelList.Add(_modelFactory.CreateShoeModel(product));
                            break;
                        case "dress":
                            modelList.Add(_modelFactory.CreateDressModel(product));
                            break;
                        default:
                            break;
                    }
                }
                return modelList;
            }
            catch { return _genericFactory.CreateGeneric<List<IProductModel>>(); }
        }
        #endregion

        #region Get one
        public async Task<IProductModel> GetProductAsync(int id)
        {
            try
            {
                var product = await _db.ProductDetail.Include(x => x.Product.ProductType).Where(p => p.ProductId == id).FirstOrDefaultAsync();
                if(product != null)
                {
                    switch (product.Product.ProductType.Name)
                    {
                        case "shoe":
                            return _modelFactory.CreateShoeModel(product);
                        case "dress":
                            return _modelFactory.CreateDressModel(product);
                        default:
                            break;
                    }
                }
            }
            catch { return _genericFactory.CreateGeneric<ProductModel>(); }
            return _genericFactory.CreateGeneric<ProductModel>();
        }
        #endregion
    }
}
