using Snow.Data.Infrastructure;
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
           : base(dbFactory)
       {

       }
        public Product GetProductByName(string productName)
        {
            var product = this.DbContext.Products.Where(c => c.Name == productName).FirstOrDefault();

            return product;
        }
        public override void Update(Product entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}