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

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Store> GetStores(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _storeRepository.GetAll();
            return _storeRepository.GetAll().Where(c => c.Name == name);
        }
    }
}
