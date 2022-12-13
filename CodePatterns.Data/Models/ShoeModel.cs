using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    public interface IShoeModel : IProductModel
    {
        int EuSize { get; set; }
        string ShoeType { get; set; }
        bool ShoeLaces { get; set; }
    }
    public class ShoeModel : ProductModel, IShoeModel
    {
        public int EuSize { get; set; }
        public string ShoeType { get; set; } = null!;
        public bool ShoeLaces { get; set; }
    }
}
