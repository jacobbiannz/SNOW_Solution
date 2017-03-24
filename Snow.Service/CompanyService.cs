using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
////using Snow.Data.Repository.Interface;
using Snow.Data.Infrastructure;

namespace Snow.Service
{
    class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IValidationDictionary _validatonDictionary;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }
    
        public void InitializeVlidation(IValidationDictionary validationDictionary)
        {
            _validatonDictionary = validationDictionary;
        }

        #region ICountryService Members

        //public void CreateCompany(Company company)
        public string CreateCompany(Company company)
        {
            if (_companyRepository.GetAll().First() != null)
            {
                _validatonDictionary.AddError("Error", "Company already exist.");
                return null;
            }
            else
            {
                _companyRepository.Add(company);
                return company.Name;
            }
            
        }
        public void UpdateCompany(Company company)
        {
            _companyRepository.Update(company);
        }
        
        public Company GetCompany(string name)
        {
            var company = _companyRepository.GetCompanyByName(name);
            return company;
        }

        public Company GetCompany(int id)
        {
            var company = _companyRepository.GetById(id);
            return company;
        }

        public IEnumerable<Company> GetCompanies(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _companyRepository.GetAll();
            return _companyRepository.GetAll().Where(c => c.Name == name);
        }

        public void SaveCompany()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveCompanyAsync()
        {
            return _unitOfWork.CommitAsync();
        }
        #endregion




    }
}
