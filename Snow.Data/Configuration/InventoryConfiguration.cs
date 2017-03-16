using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Snow.Data.Configuration
{
    public class InventoryConfiguration : EntityTypeConfiguration<Inventory>
    {
        public InventoryConfiguration()
        {
            ToTable("Inventories");
            //Property(b => b.Name).IsRequired().HasMaxLength(100);
            //Property(b => b.CompanyId);
        }
    }
}