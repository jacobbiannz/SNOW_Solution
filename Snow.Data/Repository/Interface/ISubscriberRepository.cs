﻿using Snow.Data.Infrastructure;
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
   public interface ISubscriberRepository : IRepository<Subscriber>
    {
        IEnumerable<Brand> GetBrands();

        IEnumerable<Category> GetCategories();


        IEnumerable<Company> GetCompanies();

        IEnumerable<Store> GetStores();
      
    }
}
