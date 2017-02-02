using Snow.Data.Infrastructure;
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductByName(string productName);
    }
}