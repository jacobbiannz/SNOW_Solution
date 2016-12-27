using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Description).IsRequired();
            Property(p => p.CategoryId).IsRequired();
        }
    }
}