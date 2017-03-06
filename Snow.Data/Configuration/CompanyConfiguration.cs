using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Snow.Data.Configuration
{
    public class Companyfiguration : EntityTypeConfiguration<Company>
    {
        public Companyfiguration()
        {
            ToTable("Companies");
            Property(c => c.Name).IsRequired().HasMaxLength(100);
        }
    }
}