using Snow.Data.Infrastructure;
using Snow.Model;
using Snow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductByName(string productName);

        IList<ImageInfo> GetImageInfos(int id);
    }
}