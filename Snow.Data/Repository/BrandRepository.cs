using Snow.Data.Infrastructure;
////using Snow.Data.Repository.Interface;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Brand GetBrandByName(string BrandName)
        {
            var Brand = DbContext.Brands.Where(c => c.Name == BrandName).FirstOrDefault();

            return Brand;
        }

        public override void Update(Brand entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
