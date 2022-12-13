using CodePatterns.Data.Context;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using CodePatterns.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data
{
    public interface IDataLayer
    {
        Task<IEnumerable<IProductModel>> GetProductsAsync();
        Task<IEnumerable<IProductModel>> GetProductsByCategoryAsync();
        Task<IProductModel> GetProductAsync(int id);
        Task<IActionResult> CreateProductAsync(IProductModel productModel);
        Task<IActionResult> UpdateProductAsync();
        Task<IActionResult> DeleteProductAsync();
    }
    public class DataLayer : ControllerBase, IDataLayer
    {
        private readonly SqlContext _db;
        private readonly ICreateEntities _createEntities;
        private readonly ICreateModels _createModels;
        public DataLayer(SqlContext db, 
            ICreateEntities createEntities,
            ICreateModels createModels)
        {
            _db = db;
            _createEntities = createEntities;
            _createModels = createModels;
        }

        public async Task<IEnumerable<IProductModel>> GetProductsAsync()
        {
            var products = await _db.ProductDetail
                .Include(x => x.Product)
                .Include(x => x.Product.ProductType)
                .ToListAsync();
            var news = new List<IProductModel>();
            return news;
        }
        public async Task<IEnumerable<IProductModel>> GetProductsByCategoryAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IProductModel> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> CreateProductAsync(IProductModel productModel)
        {
            //Skapar de två produkt typer om dem inte existerar redan
            var productType = _createEntities.CreateProductTypeEntity(productModel.ProductType);
            productType = await _db.ProductType.Where(x => x.Name == productModel.Name).FirstOrDefaultAsync();
            if (productType.Id == 0)
            {
                await _db.AddAsync(productType);
                await _db.SaveChangesAsync();
            }

            //Skapar ny produkt
            var product = _createEntities.CreateProductEntity(
                productModel, productType);
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();

            // Skapar nya produkt detaljer
            var productDetails = _createEntities.CreateProductDetails(productModel, product);
            await _db.AddAsync(productDetails);
            await _db.SaveChangesAsync();

            return Created("", null);
        }
        public async Task<IActionResult> UpdateProductAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> DeleteProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
