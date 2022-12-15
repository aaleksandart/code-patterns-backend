using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    public interface IDressModel : IProductModel
    {
        string DressType { get; set; }
        string DressLength { get; set; }
        string ProductType { get; set; }
    }
    public class DressModel : ProductModel, IDressModel
    {
        public string DressType { get; set; } = null!;
        public string DressLength { get; set; }
        public override string ProductType { get; set; } = "dress";
    }
}
