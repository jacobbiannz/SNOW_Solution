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
    class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SizeService(ISizeRepository SizeRepository, IUnitOfWork unitOfWork)
        {
            _sizeRepository = SizeRepository;
            _unitOfWork = unitOfWork;
        }

        #region ISizeService Members

        public void CreateSize(Size size)
        {
            _sizeRepository.Add(size);
        }
        public void UpdateSize(Size size)
        {
            _sizeRepository.Update(size);
        }
        public void DeleteSize(Size size)
        {
            _sizeRepository.Delete(size);
        }

        public Size GetSize(string name)
        {
            var size = _sizeRepository.GetSizeByName(name);
            return size;
        }

        public Size GetSize(int id)
        {
            var Size = _sizeRepository.GetById(id);
            return Size;
        }

        public IEnumerable<Size> GetSizes(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _sizeRepository.GetAll();
            return _sizeRepository.GetAll().Where(c => c.Name == name);

        }
        public void SaveSize()
        {
            _unitOfWork.Commit();
        }
        #endregion
    }
}
