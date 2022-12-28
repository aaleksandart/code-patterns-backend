using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    /// <summary>
    /// SRP: ShoeModel har bara attribut som gäller en shoe, resterande ärvs från IProduct/ProductModel.
    /// OCP: Vi kan utöka den här klassen utan att ändra på existerande kod och då använda arv.
    /// LSP: Vi kan ersätta basen ProductModel med ShoeModel om så behövs.
    /// ISP: IShoeModel ärver av IProductModel men inte av IDress vilket gör 
    /// att den bara ärver attribut som den verkligen behöver.
    /// </summary>
    public interface IShoeModel : IProductModel
    {
        string ShoeType { get; set; }
        bool? ShoeLaces { get; set; }
        bool Heels { get; set; }
    }
    public class ShoeModel : ProductModel, IShoeModel
    {
        public string ShoeType { get; set; } = "standard";
        public bool? ShoeLaces { get; set; }
        public bool Heels { get; set; }
        public override string ProductType { get; set; } = "shoe";
    }
}
