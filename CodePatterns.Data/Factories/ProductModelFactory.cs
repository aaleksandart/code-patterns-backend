using CodePatterns.Data.Models;
using CodePatterns.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Factories
{
    /// <summary>
    /// SRP: ProductModelFactory har ett jobb och det är att skapa modeller.
    /// Jag hade kunnat dela upp alla modeller i olika factories men jag
    /// tyckte inte det gjorde någon nytta.
    /// 
    /// OCP: ProductModelFactory kan utökas med funktionalitet utan att
    /// existerande kod krashar.
    /// 
    /// LSP: Det fanns inget behov att jobba med arv i denna klass.
    /// 
    /// ISP: Inte heller något behov av denna princip här.
    /// 
    /// DIP: Tack vare vår factory så följer vi DIP då vi skapar instanser 
    /// och konkreta objekt här.
    /// 
    /// DRY: Eftersom vi har en metod som sätter alla generella detaljer
    /// för en produkt oavsett produkt typ så undviker vi att repetera kod.
    /// </summary>
    /// 
    public interface IProductModelFactory
    {
        IProductModel CreateBaseProduct(ProductDetailEntity productDetails);
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
                productModel.Price = productDetails.Price;
                productModel.Color = productDetails.Color;

                return productModel;
            }
            catch { return new ProductModel(); }
        }
        
        public IProductModel CreateBaseProduct(ProductDetailEntity productDetails)
        {
            try
            {
                var productModel = new ProductModel();
                CreateProductModel(productDetails, productModel);
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
