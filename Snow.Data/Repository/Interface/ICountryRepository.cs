using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;
using Snow.Data.Infrastructure;

namespace Snow.Data.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountryByName(string countryName);
    }

}