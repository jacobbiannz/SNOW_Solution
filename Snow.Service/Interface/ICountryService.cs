using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries(string name = null);
        Country GetCountry(int id);
        Country GetCountry(string name);
        void CreateCountry(Country country);
        void UpdateCountry(Country counry);
        void DeleteCountry(Country country);
        void SaveCountry();
        Task<int> SaveCountryAsync();
    }
}
