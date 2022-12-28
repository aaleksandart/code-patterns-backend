using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    /// <summary>
    /// SRP: DressModel har bara attribut som gäller en dress, resterande ärvs från IProduct/ProductModel.
    /// OCP: Vi kan utöka den här klassen utan att ändra på existerande kod och då använda arv.
    /// LSP: Vi kan ersätta basen ProductModel med DressModel om så behövs.
    /// ISP: IDressModel ärver av IProductModel men inte av IShoe vilket gör 
    /// att den bara ärver attribut som den verkligen behöver.
    /// </summary>
    public interface IDressModel : IProductModel
    {
        string DressType { get; set; }
        string DressLength { get; set; }
    }
    public class DressModel : ProductModel, IDressModel
    {
        public string DressType { get; set; } = null!;
        public string DressLength { get; set; } = null!;
        public override string ProductType { get; set; } = "dress";
    }
}
