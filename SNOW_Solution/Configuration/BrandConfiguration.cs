using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Configuration
{
    public class BrandConfiguration : EntityTypeConfiguration<Brand>
    {
        public BrandConfiguration()
        {
            ToTable("Brands");
            Property(b => b.Name).IsRequired().HasMaxLength(100);
            Property(b => b.CompanyId).IsRequired();
        }
    }
}