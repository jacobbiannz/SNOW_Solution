using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Snow.Data.Configuration
{
    public class RegionStateConfiguration : EntityTypeConfiguration<RegionState>
    {
        public RegionStateConfiguration()
        {
            ToTable("RegionalStates");
            Property(r => r.Name).IsRequired();
            Property(r => r.CountryId);
        }
    }
}