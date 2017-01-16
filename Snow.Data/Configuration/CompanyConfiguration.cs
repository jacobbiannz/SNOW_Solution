using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Configuration
{
    public class Companyfiguration : EntityTypeConfiguration<Company>
    {
        public Companyfiguration()
        {
            ToTable("Companies");
            Property(c => c.Name).IsRequired().HasMaxLength(100);
            Property(c => c.AddressId);
            
        }
    }
}