using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;
using System.Data.Entity;

namespace SNOW_Solution.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository()
         : base()
        {

        }

        public CountryRepository(CompanyDbContext db)
           : base(db)
        {

        }

        /*
        public override IEnumerable<Country> SelectAll()
        {
            return table.ToList();
        }
        */

    }
}