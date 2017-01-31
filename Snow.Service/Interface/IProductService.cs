﻿using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(string name = null);
        Product GetProduct(int id);
        Product GetProduct(string name);
        void CreateProduct(Product product);
        void SaveProduct();
    }
}