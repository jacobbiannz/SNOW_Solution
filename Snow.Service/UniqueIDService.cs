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
    class UniqueIDService : IUniqueIDService
    {
        private readonly IUniqueIDRepository _uniqueIDRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UniqueIDService(IUniqueIDRepository UniqueIDRepository, IUnitOfWork unitOfWork)
        {
            _uniqueIDRepository = UniqueIDRepository;
            _unitOfWork = unitOfWork;
        }

        #region IUniqueIDService Members

        public void UpdateUniqueID(UniqueID uniqueID)
        {
            _uniqueIDRepository.Update(uniqueID);
        }

        public void UpdateProductBarcode(UniqueID uniqueID)
        {
            uniqueID.ProductBarcode += 1;
            _uniqueIDRepository.Update(uniqueID);
        }

        public UniqueID GetUniqueID(int id)
        {
            var UniqueID = _uniqueIDRepository.GetById(id);
            return UniqueID;
        }



        public void SaveUniqueID()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveUniqueIDAsync()
        {
           return  _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
