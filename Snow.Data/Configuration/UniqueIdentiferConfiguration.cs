using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Snow.Data.Configuration
{
    public class BrandConfiguration : EntityTypeConfiguration<Brand>
    {
        public BrandConfiguration()
        {
            ToTable("Brands");
            Property(c =>c.productBarcode).IsRequired();
        }
    }
}