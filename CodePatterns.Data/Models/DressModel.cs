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
        string DressSize { get; set; }
    }
    public class DressModel : ProductModel, IDressModel
    {
        public string DressType { get; set; } = null!;
        public string DressSize { get; set; } = null!;
    }
}
