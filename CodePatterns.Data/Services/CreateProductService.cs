using CodePatterns.Data.Context;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Services
{
    /// <summary>
    /// SRP: CreateProductService har ett jobb, att skapa nya produkter.
    /// 
    /// OCP: Vi kan utöka den här klassen utan att ändra på existerande kod.
    /// 
    /// ISP: Vi använder ICreateProductService så att andra klasser bara har tillgång
    /// till det som behövs för att skapa en produkt.
    /// 
    /// DIP: Vår service har inget konkret beroende utan beroendet är abstrakt 
    /// genom interfaces och dependency injection för att nå factories och skapa objekt.
    /// 
    /// DRY: Vi använder en privat metod för att sätta allt som är generellt för en produkt.
    /// </summary>
    public interface ICreateProductService
    {
        Task<bool> CreateShoeAsync(IShoeModel shoeModel);
        Task<bool> CreateDressAsync(IDressModel dressModel);
    }
    public class CreateProductService : ICreateProductService
    {
        private readonly SqlContext _db;
        private readonly IProductEntityFactory _entityFactory;
        private readonly IGenericFactory _genericFactory;
        public CreateProductService(SqlContext db, IProductEntityFactory entityFactory, IGenericFactory genericFactory)
        {
            _db = db;
            _entityFactory = entityFactory;
            _genericFactory = genericFactory;
        }

        #region Create product
        private async Task<ProductEntity> CreateProductAsync(IProductModel productModel)
        {
            try
            {
                //Creting product type if it not exists
                var productType = await _db.ProductType.Where(t => t.Name == productModel.ProductType).FirstOrDefaultAsync();
                if (productType == null)
                {
                    productType = _entityFactory.CreateProductType(productModel.ProductType);
                    await _db.ProductType.AddAsync(productType);
                    await _db.SaveChangesAsync();
                }

                //Creating the product
                var product = _entityFactory.CreateProduct(productType, productModel);
                await _db.Product.AddAsync(product);
                await _db.SaveChangesAsync();

                return product;
            }
            catch { return _genericFactory.CreateGeneric<ProductEntity>(); }
        }

        public async Task<bool> CreateShoeAsync(IShoeModel shoeModel)
        {
            try
            {
                //Creating product and product type
                var product = await CreateProductAsync(shoeModel);

                //Creating shoe details
                var productDetails = _entityFactory.CreateShoeDetails(shoeModel, product);
                await _db.ProductDetail.AddAsync(productDetails);
                await _db.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }

        public async Task<bool> CreateDressAsync(IDressModel dressModel)
        {
            try
            {
                //Creating product and product type
                var product = await CreateProductAsync(dressModel);

                //Creating shoe details
                var productDetails = _entityFactory.CreateDressDetails(dressModel, product);
                await _db.ProductDetail.AddAsync(productDetails);
                await _db.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        #endregion
    }
}
