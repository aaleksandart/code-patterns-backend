using CodePatterns.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data
{
    public interface IDataLayer
    {
        Task<IEnumerable<IProductModel>> GetProductsAsync();
        Task<IEnumerable<IProductModel>> GetProductsByCategoryAsync();
        Task<IProductModel> GetProductAsync(int id);
        Task<bool> CreateProductAsync();
        Task<bool> UpdateProductAsync();
        Task<bool> DeleteProductAsync();
    }
    public class DataLayer : IDataLayer
    {
        public async Task<IEnumerable<IProductModel>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<IProductModel>> GetProductsByCategoryAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IProductModel> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> CreateProductAsync()
        {
            throw new NotImplementedException();
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
