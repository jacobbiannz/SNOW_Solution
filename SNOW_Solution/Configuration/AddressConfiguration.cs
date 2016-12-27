using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Configuration
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Addresses");
            Property(a => a.CityId).IsRequired();
            Property(a => a.AddressLine1);
        }
    }
}