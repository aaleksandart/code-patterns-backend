using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        public string Color { get; set; } = "white";

        [AllowNull]
        public string? ShoeType { get; set; }
        [AllowNull]
        public bool? ShoeLaces { get; set; }
        [AllowNull]
        public bool Heels { get; set; }

        [AllowNull]
        public string? DressType { get; set; }
        [AllowNull]
        public string? DressLength { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
