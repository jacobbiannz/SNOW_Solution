using Snow.Data.Infrastructure;
using Snow.Model;
using Snow.Model.Models;
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

        public IList<ImageInfo> GetImageInfos(int id)
        {
            var imageInfos = new List<ImageInfo>();
            foreach (var info in DbContext.ImageInfos)
            {
                if (info.ProductId == id)
                {
                    imageInfos.Add(info);
                }
            }
            return imageInfos;
        }
    }
}