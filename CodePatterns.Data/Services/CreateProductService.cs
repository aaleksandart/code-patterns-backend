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
    public interface ICreateProductService
    {
        Task<bool> CreateProductAsync(IProductModel productModel);
    }
    public class CreateProductService : ICreateProductService
    {
        private readonly SqlContext _db;
        private readonly IProductEntityFactory _entityFactory;
        public CreateProductService(SqlContext db, IProductEntityFactory entityFactory)
        {
            _db = db;
            _entityFactory = entityFactory;
        }

        #region Create product
        public async Task<bool> CreateProductAsync(IProductModel productModel)
        {
            try
            {
                //Skapar produkttyp
                var productType = await _db.ProductType.Where(t => t.Name == productModel.ProductType).FirstOrDefaultAsync();
                if (productType == null)
                {
                    productType = _entityFactory.CreateProductType(productModel.ProductType);
                    await _db.ProductType.AddAsync(productType);
                    await _db.SaveChangesAsync();
                }

                //Skapar produkten
                var product = _entityFactory.CreateProduct(productType, productModel);
                await _db.Product.AddAsync(product);
                await _db.SaveChangesAsync();

                //Skapar produkt detaljerna
                var productDetails = _entityFactory.CreateProductDetailEntity(productModel, product);
                await _db.ProductDetail.AddAsync(productDetails);
                await _db.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        #endregion
    }
}
