using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;
using Snow.Data.Infrastructure;

namespace SNOW_Solution.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountryByName(string countryName);
    }

}