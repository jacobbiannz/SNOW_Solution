using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOW_Solution.Models;
using Snow.Data.Repository;
using Snow.Data.Repository.Interface;
using Snow.Data.Infrastructure;

namespace Snow.Service.Interface
{
    class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Company> GetCompanies(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _companyRepository.GetAll();
            return _companyRepository.GetAll().Where(c => c.Name == name);
        }
    }
}
