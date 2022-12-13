using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models.Entities
{
    public class ProductDetailEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid Barcode { get; set; }
        public string Color { get; set; } = null!;

        public int? EuSize { get; set; }
        public string? ShoeType { get; set; }
        public bool? ShoeLaces { get; set; }

        public string? DressType { get; set; }
        public string? DressSize { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
