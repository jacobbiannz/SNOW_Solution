using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IStoreService
    {
        IEnumerable<Store> GetStores(string name = null);
        Store GetStore(int id);
        Store GetStore(string name);
        void CreateStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Store store);
        void SaveStore();

    }
}
