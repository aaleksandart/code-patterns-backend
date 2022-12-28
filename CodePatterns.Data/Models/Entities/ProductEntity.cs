using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models.Entities
{
    /// <summary>
    /// ProductEntity innehåller generell fakta om produkten.
    /// Detta innehåll är detsamma oavsett typ av produkt.
    /// </summary>
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = null!;

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductTypeEntity? ProductType { get; set; }
    }
}
