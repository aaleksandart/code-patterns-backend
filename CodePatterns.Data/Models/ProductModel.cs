using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    /// <summary>
    /// Basen för alla produkter ProductModel har alla generalla attribut för en produkt.
    /// SRP: ProductModel har bara attribut som gäller en produkt.
    /// OCP: Vi kan utöka den här klassen utan att ändra på existerande kod och då använda arv.
    /// LSP: Vi kan ersätta basen med IShoe eller IDress.
    /// ISP: Alla specifika produkters interface ärver av detta interface.
    /// </summary>
    public interface IProductModel
    {
        int Id { get; set; }
        string ProductType { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Guid Barcode { get; set; }
        decimal Price { get; set; }
        string Color { get; set; }

    }
    public class ProductModel : IProductModel
    {
        public int Id { get; set; }
        public virtual string ProductType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty!;
        public Guid Barcode { get; set; }
        public virtual decimal Price { get; set; }
        public string Color { get; set; } = null!;
    }
}
