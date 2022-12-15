using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Factories
{
    public interface IProductEntityFactory
    {
        ProductTypeEntity CreateProductType(string typeName);
        ProductEntity CreateProduct(ProductTypeEntity productType, IProductModel productModel);
        ProductDetailEntity CreateProductDetailEntity(IProductModel productModel, ProductEntity product);
    }
    public class ProductEntityFactory : IProductEntityFactory
    {
        public ProductTypeEntity CreateProductType(string typeName)
        {
            var productType = new ProductTypeEntity();
            productType.Name = typeName;
            return productType;
        }

        public ProductEntity CreateProduct(ProductTypeEntity productType, IProductModel productModel)
        {
            var product = new ProductEntity();
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.ProductTypeId = productType.Id;
            product.ProductType = productType;

            return product;
        }

        public ProductDetailEntity CreateProductDetailEntity(IProductModel productModel, ProductEntity product)
        {
            var productDetails = new ProductDetailEntity();
            productDetails.Barcode = Guid.NewGuid();
            productDetails.Color = productModel.Color;
            productDetails.ProductId = product.Id;
            productDetails.Product = product;

            switch (productModel.ProductType)
            {
                case "shoe":
                    return SetShoeDetails(productDetails, (IShoeModel)productModel);
                case "dress":
                    return SetDressDetails(productDetails, (IDressModel)productModel);
                default:
                    return productDetails;
            }
        }

        #region Set specific product details
        private ProductDetailEntity SetShoeDetails(ProductDetailEntity productDetails, IShoeModel shoeModel)
        {
            productDetails.ShoeType = shoeModel.ShoeType;
            productDetails.ShoeLaces = shoeModel.ShoeLaces;
            productDetails.Heels = shoeModel.Heels;

            return productDetails;
        }
        private ProductDetailEntity SetDressDetails(ProductDetailEntity productDetails, IDressModel dressModel)
        {
            productDetails.DressType = dressModel.DressType;
            productDetails.DressLength = dressModel.DressLength;

            return productDetails;
        }
        #endregion
    }
}
