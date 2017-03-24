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
    class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IStoreRepository StoreRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = StoreRepository;
            _unitOfWork = unitOfWork;
        }

        #region IStoreService Members

        public void CreateStore(Store store)
        {
            _storeRepository.Add(store);
        }
        public void UpdateStore(Store store)
        {
            _storeRepository.Update(store);
        }
        public void DeleteStore(Store store)
        {
            _storeRepository.Delete(store);
        }

        public Store GetStore(string name)
        {
            var store = _storeRepository.GetStoreByName(name);
            return store;
        }

        public Store GetStore(int id)
        {
            var Store = _storeRepository.GetById(id);
            return Store;
        }

        public IEnumerable<Store> GetStores(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _storeRepository.GetAll();
            return _storeRepository.GetAll().Where(c => c.Name == name);

        }
        public void SaveStore()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveStoreAsync()
        {
            return _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
