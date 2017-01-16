using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;
using System.Data.Entity;
using Snow.Data.Infrastructure;

namespace SNOW_Solution.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
      
        public CountryRepository(IDbFactory dbFactory)
           : base(dbFactory)
        {

        }
        public Country GetCountryByName(string countryName)
        {
            var country = this.DbContext.Countries.Where(c => c.Name == countryName).FirstOrDefault();

            return country;
        }

    }
}