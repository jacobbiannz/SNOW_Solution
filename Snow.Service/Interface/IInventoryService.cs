using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IInventoryService
    {
        //IEnumerable<Inventory> GetInventorys(string name = null);
        Inventory GetInventory(int id);
        //Inventory GetInventory(string name);
        void CreateInventory(Inventory inventory);
        void UpdateInventory(Inventory inventory);
        void DeleteInventory(Inventory inventory);
        void SaveInventory();
        Task<int> SaveInventoryAsync();
    }
}
