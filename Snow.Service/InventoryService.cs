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
    class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IInventoryRepository InventoryRepository, IUnitOfWork unitOfWork)
        {
            _inventoryRepository = InventoryRepository;
            _unitOfWork = unitOfWork;
        }

        #region IInventoryService Members

        public void CreateInventory(Inventory inventory)
        {
            _inventoryRepository.Add(inventory);
        }
        public void UpdateInventory(Inventory inventory)
        {
            _inventoryRepository.Update(inventory);
        }
        /*
        public void DeleteInventory(Inventory inventory)
        {
            _inventoryRepository.Delete(inventory);
        }
        */
        /*
        public Inventory GetInventory(string name)
        {
            var inventory = _inventoryRepository.GetInventoryByName(name);
            return inventory;
        }
        */

        public Inventory GetInventory(int id)
        {
            var Inventory = _inventoryRepository.GetById(id);
            return Inventory;
        }

        public Inventory GetInventory(Store store, Product product, Size size)
        {
            var Inventory = _inventoryRepository.GetInventoryBySPS(store, product, size);
            return Inventory;
        }
        /*
        public IEnumerable<Inventory> GetInventorys(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _inventoryRepository.GetAll();
            return _inventoryRepository.GetAll().Where(c => c.Name == name);

        }
        */
        public void SaveInventory()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveInventoryAsync()
        {
            return _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
