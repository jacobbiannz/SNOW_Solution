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
    class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Brand> GetBrands(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _brandRepository.GetAll();
            return _brandRepository.GetAll().Where(c => c.Name == name);
        }
    }
}
