using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;
using System.Data.Entity;
using Snow.Data.Infrastructure;

namespace Snow.Data.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
      
        public CountryRepository(IDbFactory dbFactory)
           : base(dbFactory)
        {

        }
        public Country GetCountryByName(string countryName)
        {
            var country = DbContext.Countries.Where(c => c.Name == countryName).FirstOrDefault();

            return country;
        }  
        public override void Update(Country entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }

    }
}