using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IUniqueIDService
    {
        UniqueID GetUniqueID(int id);
        //void CreateUniqueID(UniqueID uniqueID);
        void UpdateUniqueID(UniqueID uniqueID);
        void UpdateProductBarcode(UniqueID uniqueID);
        
        //void DeleteUniqueID(UniqueID uniqueID);
        void SaveUniqueID();
        Task<int> SaveUniqueIDAsync();
    }
}
