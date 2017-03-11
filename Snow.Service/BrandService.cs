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

        public BrandService(IBrandRepository BrandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = BrandRepository;
            _unitOfWork = unitOfWork;
        }

        #region IBrandService Members

        public void CreateBrand(Brand brand)
        {
            _brandRepository.Add(brand);
        }
        public void UpdateBrand(Brand brand)
        {
            _brandRepository.Update(brand);
        }
        public void DeleteBrand(Brand brand)
        {
            _brandRepository.Delete(brand);
        }

        public Brand GetBrand(string name)
        {
            var brand = _brandRepository.GetBrandByName(name);
            return brand;
        }

        public Brand GetBrand(int id)
        {
            var Brand = _brandRepository.GetById(id);
            return Brand;
        }

        public IEnumerable<Brand> GetBrands(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _brandRepository.GetAll();
            return _brandRepository.GetAll().Where(c => c.Name == name);

        }
        public void SaveBrand()
        {
            _unitOfWork.Commit();
        }
        #endregion
    }
}
