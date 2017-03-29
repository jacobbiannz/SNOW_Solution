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
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IInventoryRepository InventoryRepository, IStoreRepository StoreRepository, IUnitOfWork unitOfWork)
        {
            _inventoryRepository = InventoryRepository;
            _storeRepository = StoreRepository;
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
        
        public IEnumerable<Inventory> GetInventorys(string Store = null)
        {
            if (string.IsNullOrEmpty(Store))
                return _inventoryRepository.GetAll();
            return _inventoryRepository.GetAll().Where(c => c.MyStore.Name == Store);
        }

        public void GenerateInventory()
        {
            foreach (var store in _storeRepository.GetAll())
            {
                foreach (var product in store.MyCompany.AllProducts)
                {
                    if (product.MyCategory != null)
                        foreach (var size in product.MyCategory.AllSizes)
                        {
                            if (GetInventory(store, product, size) == null)
                            {
                                var inventory = new Inventory();
                                inventory.StoreId = store.Id;
                                inventory.ProductId = product.Id;
                                inventory.SizeId = size.Id;

                                CreateInventory(inventory);
                                SaveInventory();
                            }
                        }
                }
            }
        }


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
