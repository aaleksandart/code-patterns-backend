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
    /// SRP: ProductEntityFactory har ett jobb och det är att skapa entities.
    /// Jag hade kunnat dela upp alla entities i olika factories men jag
    /// tyckte inte det gjorde någon nytta.
    /// 
    /// OCP: ProductEntityFactory kan utökas med funktionalitet utan att
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
    public interface IProductEntityFactory
    {
        ProductTypeEntity CreateProductType(string typeName);
        ProductEntity CreateProduct(ProductTypeEntity productType, IProductModel productModel);
        ProductDetailEntity CreateShoeDetails(IShoeModel shoeModel, ProductEntity productEntity);
        ProductDetailEntity CreateDressDetails(IDressModel dressModel, ProductEntity productEntity);
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

        public ProductDetailEntity CreateShoeDetails(IShoeModel shoeModel, ProductEntity productEntity)
        {
            var productDetails = CreateProductDetailEntity(shoeModel, productEntity);
            productDetails.ShoeType = shoeModel.ShoeType;
            productDetails.ShoeLaces = shoeModel.ShoeLaces;
            productDetails.Heels = shoeModel.Heels;

            return productDetails;
        }
        public ProductDetailEntity CreateDressDetails(IDressModel dressModel, ProductEntity productEntity)
        {
            var productDetails = CreateProductDetailEntity(dressModel, productEntity);
            productDetails.DressType = dressModel.DressType;
            productDetails.DressLength = dressModel.DressLength;

            return productDetails;
        }

        private ProductDetailEntity CreateProductDetailEntity(IProductModel productModel, ProductEntity product)
        {
            var productDetails = new ProductDetailEntity();
            productDetails.Barcode = Guid.NewGuid();
            productDetails.Price = productModel.Price;
            productDetails.Color = productModel.Color;
            productDetails.ProductId = product.Id;
            productDetails.Product = product;

            return productDetails;
        }
    }
}
