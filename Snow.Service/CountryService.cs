using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
using Snow.Data.Infrastructure;

namespace Snow.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICountryService Members

        public void CreateCountry(Country country)
        {
            countryRepository.Add(country);
        }
        public void UpdateCountry(Country country)
        {
            countryRepository.Update(country);
        }
        public void DeleteCountry(Country country)
        {
            countryRepository.Delete(country);
        }

        public Country GetCountry(string name)
        {
            var country = countryRepository.GetCountryByName(name);
            return country;
        }

        public Country GetCountry(int id)
        {
            var country = countryRepository.GetById(id);
            return country;
        }

        public IEnumerable<Country> GetCountries(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return countryRepository.GetAll();
            else
                return countryRepository.GetAll().Where(c => c.Name == name);
        }

        public void SaveCountry()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
