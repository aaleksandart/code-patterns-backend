using CodePatterns.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }
        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Product { get; set; }
        public virtual DbSet<ProductTypeEntity> ProductType { get; set; }
        public virtual DbSet<ProductDetailEntity> ProductDetail { get; set; }
    }
}
