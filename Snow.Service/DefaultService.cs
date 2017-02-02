using Snow.Service.Interface;
using System;
using System.Collections.Generic;
using SNOW_Solution.Models;
using Snow.Data.Infrastructure;
using Snow.Data.Repository;
using System.Linq;

namespace Snow.Service
{
    class DefaultService : IDefaultService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DefaultService(ISubscriberRepository subscriberRepository, IUnitOfWork unitOfWork)
        {
            _subscriberRepository = subscriberRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Brand> GetBrands(int brandId=0)
        {
            if (string.IsNullOrEmpty(brandId.ToString()))
                return _subscriberRepository.GetBrands();
            else
                return _subscriberRepository.GetBrands().Where(c => c.Id == brandId);
        }

        public IEnumerable<Category> GetCategories(int categoryId=0)
        {
            if (string.IsNullOrEmpty(categoryId.ToString()))
                return _subscriberRepository.GetCategories();
            else
                return _subscriberRepository.GetCategories().Where(c => c.Id == categoryId);
        }

        public IEnumerable<Company> GetCompanies(int companyId=0)
        {
            if (string.IsNullOrEmpty(companyId.ToString()))
                return _subscriberRepository.GetCompanies();
            else
                return _subscriberRepository.GetCompanies().Where(c => c.Id == companyId);
        }

        public IEnumerable<Store> GetStores(int storeId=0)
        {
            if (string.IsNullOrEmpty(storeId.ToString()))
                return _subscriberRepository.GetStores();
            else
                return _subscriberRepository.GetStores().Where(c => c.Id == storeId);
        }
    }
}
