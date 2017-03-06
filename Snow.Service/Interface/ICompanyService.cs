using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface ICompanyService : IValidate
    {
        IEnumerable<Company> GetCompanies(string name = null);
        Company GetCompany(int id);
        Company GetCompany(string name);
        string CreateCompany(Company company);
        void UpdateCompany(Company company);
        //void DeleteCountry(Country country);
        void SaveCompany();
    }
}
