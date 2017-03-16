using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Snow.Data.Configuration
{
    public class SizeConfiguration : EntityTypeConfiguration<Size>
    {
        public SizeConfiguration()
        {
            ToTable("Sizes");
            Property(b => b.Name).IsRequired().HasMaxLength(50);
            Property(b => b.CategoryId);
        }
    }
}