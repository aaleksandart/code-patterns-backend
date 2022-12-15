using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Factories
{
    public interface IProductModelFactory
    {
        IShoeModel CreateShoeModel(ProductDetailEntity productDetails);
        IDressModel CreateDressModel(ProductDetailEntity productDetails);
    }
    public class ProductModelFactory : IProductModelFactory
    {
        private IProductModel CreateProductModel(ProductDetailEntity productDetails, IProductModel productModel)
        {
            try
            {
                productModel.Id = productDetails.Id;
                productModel.ProductType = productDetails.Product.ProductType.Name;
                productModel.Name = productDetails.Product.Name;
                productModel.Description = productDetails.Product.Description;
                productModel.Barcode = productDetails.Barcode;
                productModel.Color = productDetails.Color;

                return productModel;
            }
            catch { return new ProductModel(); }
        }

        public IShoeModel CreateShoeModel(ProductDetailEntity productDetails)
        {
            try
            {
                var shoeModel = new ShoeModel();
                CreateProductModel(productDetails, shoeModel);
                shoeModel.ShoeType = productDetails.ShoeType;
                shoeModel.ShoeLaces = productDetails.ShoeLaces;
                shoeModel.Heels = productDetails.Heels;

                return shoeModel;
            }
            catch { return new ShoeModel(); }
        }

        public IDressModel CreateDressModel(ProductDetailEntity productDetails)
        {
            try
            {
                var dressModel = new DressModel();
                CreateProductModel(productDetails, dressModel);
                dressModel.DressType = productDetails.DressType;
                dressModel.DressLength = productDetails.DressLength;

                return dressModel;
            }
            catch { return new DressModel(); }
        }
    }
}
