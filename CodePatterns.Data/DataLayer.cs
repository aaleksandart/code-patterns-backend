using CodePatterns.Data.Context;
using CodePatterns.Data.Factories;
using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using CodePatterns.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data
{
    public interface IDataLayer
    {
        Task<IEnumerable<IProductModel>> GetProductsAsync();
        Task<ObjectResult> GetProductAsync(int id);
        Task<IActionResult> CreateProductAsync(IProductModel productModel);
        Task<IActionResult> UpdateProductAsync();
        Task<IActionResult> DeleteProductAsync();
    }
    public class DataLayer : ControllerBase, IDataLayer
    {
        private readonly ICreateProductService _createProduct;
        private readonly IGetProductService _getProduct;
        public DataLayer(ICreateProductService createProduct, IGetProductService getProduct)
        {
            _createProduct = createProduct;
            _getProduct = getProduct;
        }

        #region Get product
        public async Task<IEnumerable<IProductModel>> GetProductsAsync() =>
            await _getProduct.GetProductsAsync();
        public async Task<ObjectResult> GetProductAsync(int id)
        {
            try
            {
                var product = await _getProduct.GetProductAsync(id);
                if (product.Id == 0)
                    return NotFound(product);
                return Ok(product);
            }
            catch { return new ObjectResult(StatusCode(500)); }
        }
        #endregion

        #region Create product
        public async Task<IActionResult> CreateProductAsync(IProductModel productModel)
        {
            var created = await _createProduct.CreateProductAsync(productModel);
            if (!created)
                return BadRequest();

            return Created("", null);
        }
        #endregion

        #region Update product
        public async Task<IActionResult> UpdateProductAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete product
        public async Task<IActionResult> DeleteProductAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
