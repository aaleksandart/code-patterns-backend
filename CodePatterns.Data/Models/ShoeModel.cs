using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    public interface IShoeModel : IProductModel
    {
        string ShoeType { get; set; }
        bool? ShoeLaces { get; set; }
        bool Heels { get; set; }
        string ProductType { get; set; }
    }
    public class ShoeModel : ProductModel, IShoeModel
    {
        public string ShoeType { get; set; } = "standard";
        public bool? ShoeLaces { get; set; }
        public bool Heels { get; set; }
        public override string ProductType { get; set; } = "shoe";
    }
}
