using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models
{
    public interface IProductModel
    {
        int Id { get; set; }
        string ProductType { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Guid Barcode { get; set; }
        string Color { get; set; }

    }
    public class ProductModel : IProductModel
    {
        public int Id { get; set; }
        public virtual string ProductType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty!;
        public Guid Barcode { get; set; }
        public string Color { get; set; } = null!;
    }
}
