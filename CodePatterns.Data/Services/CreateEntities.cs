using CodePatterns.Data.Factories;
using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Services
{
    public interface ICreateEntities
    {
        ProductEntity CreateProductEntity(IProductModel model, ProductTypeEntity productType);
        ProductTypeEntity CreateProductTypeEntity(string typeName);
        ProductDetailEntity CreateProductDetails(IProductModel model, ProductEntity product);
    }
    public class CreateEntities : ICreateEntities
    {
        private readonly IProductFactory _factory;
        public CreateEntities(IProductFactory factory)
        {
            _factory = factory;
        }
        #region ProductEntity
        public ProductEntity CreateProductEntity(IProductModel model, ProductTypeEntity productType)
        {
            try
            {
                var product = _factory.CreateProduct<ProductEntity>();
                product.Name = model.Name;
                product.Description = model.Description;
                product.ProductTypeId = productType.Id;
                product.ProductType = productType;

                return product;
            }
            catch { return _factory.CreateProduct<ProductEntity>(); }
        }
        #endregion

        #region ProductTypeEntity
        public ProductTypeEntity CreateProductTypeEntity(string typeName)
        {
            try
            {
                var product = _factory.CreateProduct<ProductTypeEntity>();
                product.Name = typeName;

                return product;
            }
            catch { return _factory.CreateProduct<ProductTypeEntity>(); }
        }
        #endregion

        #region ProductDetailEntity
        public ProductDetailEntity CreateProductDetails(IProductModel model, ProductEntity product)
        {
            try
            {
                var productDetails = _factory.CreateProduct<ProductDetailEntity>();
                productDetails.Barcode = Guid.NewGuid();
                productDetails.Color = model.Color;

                if(model.ProductType == "shoe")
                {
                    var shoe = model as ShoeModel;
                    productDetails.EuSize = shoe.EuSize;
                    productDetails.ShoeType = shoe.ShoeType;
                    productDetails.ShoeLaces = shoe.ShoeLaces;
                }
                else
                {
                    var dress = model as DressModel;
                    productDetails.DressSize = dress.DressSize;
                    productDetails.DressType = dress.DressType;
                }
                
                productDetails.ProductId = product.Id;
                productDetails.Product = product;

                return productDetails;
            }
            catch { return _factory.CreateProduct<ProductDetailEntity>(); }
        }
        #endregion
    }
}
