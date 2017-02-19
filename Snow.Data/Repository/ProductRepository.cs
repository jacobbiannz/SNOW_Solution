using Snow.Data.Infrastructure;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Snow.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
           : base(dbFactory)
       {

       }
        public Product GetProductByName(string productName)
        {
            var product = DbContext.Products.Where(c => c.Name == productName).FirstOrDefault();

            return product;
        }
        public override void Update(Product entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}