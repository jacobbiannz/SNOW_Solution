using Snow.Data.Infrastructure;
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
   public class SubscriberRepository : RepositoryBase<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Brand> GetBrands()
        {
            return DbContext.Brands;
        }
        public IEnumerable<Category> GetCategories()
        {
            return DbContext.Categories;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return DbContext.Companys;
        }
        public IEnumerable<Store> GetStores()
        {
            return DbContext.Stores;
        }
    }
}
