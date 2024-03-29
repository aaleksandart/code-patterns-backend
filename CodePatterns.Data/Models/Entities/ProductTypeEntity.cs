﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Models.Entities
{
    /// <summary>
    /// ProductTypeEntity innehåller de produkttyper som finns. 
    /// </summary>
    public class ProductTypeEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;
    }
}
