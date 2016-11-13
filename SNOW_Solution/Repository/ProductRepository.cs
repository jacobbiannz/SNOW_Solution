using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CompanyDbContext db)
           : base(db)
       {

       }
        public ProductRepository()
          : base()
        {

        }
        public override IEnumerable<Product> SelectAll()
        {
            return table.ToList();
        }

    }
}