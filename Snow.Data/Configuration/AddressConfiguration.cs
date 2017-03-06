using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Snow.Data.Configuration
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Addresses");
            Property(a => a.CityId);
            Property(a => a.AddressLine1);
            //Property(a => a.PhoneNumber).IsRequired();
            //Property(a => a.Email).IsRequired();
        }
    }
}