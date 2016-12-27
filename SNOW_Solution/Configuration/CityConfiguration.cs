using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Configuration
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            ToTable("Cities");
            Property(c => c.Name).IsRequired();
            Property(c => c.CountryId).IsRequired();
        }
    }
}