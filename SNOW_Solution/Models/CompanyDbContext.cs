using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SNOW_Solution;

namespace SNOW_Solution.Models
{
    public class CompanyDbContext : DbContext
    {
        //public DbSet<Company> Companys { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Product> Products { get; set; }
    }
}